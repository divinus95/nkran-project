-- 1. Create the enum type first
CREATE TYPE user_role AS ENUM ('customer', 'owner', 'representative', 'admin');

-- 2. Create the table using the new type
CREATE TABLE users (
    id SERIAL PRIMARY KEY,
    uuid UUID UNIQUE DEFAULT gen_random_uuid(),
    email VARCHAR(255) UNIQUE NOT NULL,
    phone VARCHAR(20) UNIQUE,
    password_hash TEXT NOT NULL,
    role user_role NOT NULL, -- Custom type applied here
    full_name VARCHAR(255),
    profile_picture TEXT,
    location GEOMETRY(Point, 4326),
    preferences JSONB,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    is_verified BOOLEAN DEFAULT FALSE
);


-- Businesses/Services
CREATE TABLE businesses (
    id SERIAL PRIMARY KEY,
    owner_id INTEGER REFERENCES users(id),
    name VARCHAR(255) NOT NULL,
    category VARCHAR(100) NOT NULL,  -- laundry, barber, restaurant, etc.
    description TEXT,
    address TEXT,
    location GEOMETRY(Point, 4326) NOT NULL,
    contact_phone VARCHAR(20),
    rating DECIMAL(3,2) DEFAULT 0,
    is_approved BOOLEAN DEFAULT FALSE,
    operating_hours JSONB,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Representatives (linked to owners)
CREATE TABLE representatives (
    id SERIAL PRIMARY KEY,
    user_id INTEGER REFERENCES users(id),
    business_id INTEGER REFERENCES businesses(id),
    role VARCHAR(100)  -- delivery, attendant
);

-- Bookings/Orders
CREATE TABLE bookings (
    id SERIAL PRIMARY KEY,
    customer_id INTEGER REFERENCES users(id),
    business_id INTEGER REFERENCES businesses(id),
    service_details JSONB,
    booking_time TIMESTAMP,
    status ENUM('pending', 'confirmed', 'completed', 'cancelled'),
    total_amount DECIMAL(10,2),
    payment_status ENUM('pending', 'paid', 'failed')
);

-- Payments
CREATE TABLE payments (
    id SERIAL PRIMARY KEY,
    booking_id INTEGER REFERENCES bookings(id),
    amount DECIMAL(10,2),
    momo_transaction_id VARCHAR(100),
    status VARCHAR(50),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Reviews
CREATE TABLE reviews (
    id SERIAL PRIMARY KEY,
    booking_id INTEGER REFERENCES bookings(id),
    user_id INTEGER REFERENCES users(id),
    business_id INTEGER REFERENCES businesses(id),
    rating INTEGER CHECK (rating BETWEEN 1 AND 5),
    comment TEXT,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Indexes for performance
CREATE INDEX idx_business_location ON businesses USING GIST(location);
CREATE INDEX idx_user_role ON users(role);