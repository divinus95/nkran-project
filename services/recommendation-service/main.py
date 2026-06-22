from fastapi import FastAPI
app = FastAPI(title="Nkran Recommendation Service")

@app.get("/recommend")
async def recommend(user_id: int, lat: float, lon: float):
    # TODO: AI logic here
    return {"recommendations": []}