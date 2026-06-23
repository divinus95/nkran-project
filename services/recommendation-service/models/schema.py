# recommendation-service/models/schemas.py
from pydantic import BaseModel, Field
from typing import Optional
from enum import Enum
from datetime import datetime
import uuid


# ─── ENUMS ────────────────────────────────────────────────────

class ServiceCategory(str, Enum):
    laundry = "laundry"
    barbering = "barbering"
    salon = "salon"
    restaurant = "restaurant"
    fast_food = "fast_food"
    pub = "pub"
    bar = "bar"
    church = "church"
    car_rental = "car_rental"
    pharmacy = "pharmacy"
    clinic = "clinic"
    hotel = "hotel"
    grocery = "grocery"
    gym = "gym"
    market = "market"
    mechanic = "mechanic"
    other = "other"


# ─── REQUEST SCHEMAS ──────────────────────────────────────────

class RecommendRequest(BaseModel):
    user_id: Optional[str] = None
    session_id: Optional[str] = None
    lat: float = Field(..., ge=-90, le=90, description="User latitude")
    lng: float = Field(..., ge=-180, le=180, description="User longitude")
    category: Optional[ServiceCategory] = None
    radius_km: float = Field(default=10.0, ge=0.5, le=50.0)
    limit: int = Field(default=10, ge=1, le=50)
    exclude_ids: list[str] = Field(default=[], description="Business IDs to exclude")


class SearchRequest(BaseModel):
    query: str = Field(..., min_length=1, max_length=200)
    lat: Optional[float] = None
    lng: Optional[float] = None
    category: Optional[ServiceCategory] = None
    radius_km: float = Field(default=10.0)
    page: int = Field(default=1, ge=1)
    page_size: int = Field(default=20, ge=1, le=50)
    user_id: Optional[str] = None
    session_id: Optional[str] = None


class LogInteractionRequest(BaseModel):
    user_id: Optional[str] = None
    session_id: Optional[str] = None
    business_id: str
    action: str = Field(..., description="view|click|save|share|call")
    source: Optional[str] = Field(None, description="search|recommendation|category|map")
    duration_secs: Optional[int] = None


class LogRecommendationRequest(BaseModel):
    user_id: Optional[str] = None
    session_id: Optional[str] = None
    lat: Optional[float] = None
    lng: Optional[float] = None
    category: Optional[str] = None
    query_text: Optional[str] = None
    results: list[dict]


class ClickFeedbackRequest(BaseModel):
    log_id: str
    clicked_business_id: str
    booked: bool = False


# ─── RESPONSE SCHEMAS ─────────────────────────────────────────

class BusinessScore(BaseModel):
    id: str
    name: str
    category: str
    address: str
    lat: float
    lng: float
    avg_rating: float
    total_reviews: int
    total_bookings: int
    logo_url: Optional[str] = None
    tags: list[str] = []
    distance_m: float
    rec_score: float
    score_breakdown: Optional[dict] = None  # For debug mode


class SearchResult(BaseModel):
    id: str
    name: str
    category: str
    address: str
    lat: float
    lng: float
    avg_rating: float
    total_reviews: int
    logo_url: Optional[str] = None
    tags: list[str] = []
    distance_m: Optional[float] = None
    relevance_score: float


class RecommendResponse(BaseModel):
    results: list[BusinessScore]
    total: int
    log_id: Optional[str] = None  # For click feedback


class SearchResponse(BaseModel):
    results: list[SearchResult]
    total: int
    page: int
    page_size: int
    query: str


class TrendingResponse(BaseModel):
    category: Optional[str] = None
    city: str = "Accra"
    results: list[BusinessScore]
    period: str = "7d"


# ─── DATABASE ROW MAPPING ─────────────────────────────────────

class BusinessRow(BaseModel):
    """Maps directly from DB query result"""
    id: str
    name: str
    category: str
    address: str
    lat: float
    lng: float
    avg_rating: float = 0.0
    total_reviews: int = 0
    total_bookings: int = 0
    logo_url: Optional[str] = None
    tags: list[str] = []
    distance_m: float = 0.0
    is_featured: bool = False
    is_verified: bool = False


# ─── USER CONTEXT (for personalised scoring) ─────────────────

class UserContext(BaseModel):
    """Fetched per user to personalise recommendations"""
    user_id: str
    top_categories: list[str] = []     # Most booked categories
    saved_business_ids: list[str] = []
    booked_business_ids: list[str] = []
    searched_categories: list[str] = []
    avg_spend: Optional[float] = None


# ─── SCORING WEIGHTS ─────────────────────────────────────────

class ScoringWeights(BaseModel):
    """Configurable weights for the scoring formula"""
    rating_weight: float = 0.40
    proximity_weight: float = 0.35
    popularity_weight: float = 0.15
    personalisation_weight: float = 0.10

    class Config:
        # Weights must sum to 1.0
        json_schema_extra = {
            "example": {
                "rating_weight": 0.40,
                "proximity_weight": 0.35,
                "popularity_weight": 0.15,
                "personalisation_weight": 0.10
            }
        }


# ─── HEALTH CHECK ─────────────────────────────────────────────

class HealthResponse(BaseModel):
    status: str = "ok"
    service: str = "nkran-recommendation-service"
    version: str = "1.0.0"
    db_connected: bool = False
    timestamp: datetime = Field(default_factory=datetime.utcnow)