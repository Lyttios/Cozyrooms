-- Basic schema for players, rooms, items, trades
CREATE EXTENSION IF NOT EXISTS pgcrypto;

CREATE TABLE IF NOT EXISTS players (
  id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
  username TEXT UNIQUE NOT NULL,
  display_name TEXT,
  avatar_data JSONB,
  coins BIGINT DEFAULT 0,
  premium_balance BIGINT DEFAULT 0,
  created_at TIMESTAMP WITH TIME ZONE DEFAULT now()
);

CREATE TABLE IF NOT EXISTS rooms (
  id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
  owner_id UUID REFERENCES players(id),
  name TEXT NOT NULL,
  visibility TEXT NOT NULL DEFAULT 'friends', -- public/friends/private/password
  room_state JSONB, -- placement + furniture
  created_at TIMESTAMP WITH TIME ZONE DEFAULT now()
);

CREATE TABLE IF NOT EXISTS items (
  id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
  sku TEXT NOT NULL UNIQUE,
  name TEXT NOT NULL,
  metadata JSONB, -- size, anchors, rarity
  price_coins BIGINT DEFAULT 0,
  price_premium BIGINT DEFAULT 0,
  is_tradeable BOOLEAN DEFAULT TRUE,
  created_at TIMESTAMP WITH TIME ZONE DEFAULT now()
);

CREATE TABLE IF NOT EXISTS inventories (
  player_id UUID REFERENCES players(id) ON DELETE CASCADE,
  item_id UUID REFERENCES items(id),
  quantity INT DEFAULT 1,
  PRIMARY KEY (player_id, item_id)
);

CREATE TABLE IF NOT EXISTS friendships (
  player_a UUID REFERENCES players(id),
  player_b UUID REFERENCES players(id),
  created_at TIMESTAMP WITH TIME ZONE DEFAULT now(),
  PRIMARY KEY (player_a, player_b)
);

CREATE TABLE IF NOT EXISTS trades (
  id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
  from_player UUID REFERENCES players(id),
  to_player UUID REFERENCES players(id),
  offered JSONB,
  requested JSONB,
  status TEXT DEFAULT 'pending',
  created_at TIMESTAMP WITH TIME ZONE DEFAULT now()
);

-- Indexes for searching
CREATE INDEX IF NOT EXISTS idx_players_username ON players(username);
CREATE INDEX IF NOT EXISTS idx_rooms_owner ON rooms(owner_id);
