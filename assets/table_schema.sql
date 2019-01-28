DROP TABLE IF EXISTS "highscores";
DROP TABLE IF EXISTS "countries";

CREATE TABLE "highscores" (
  "id" int(11) NOT NULL,
  "playername" VARCHAR(75) NOT NULL DEFAULT "",
  "score" int(11) NOT NULL DEFAULT 0,
  PRIMARY KEY ("id")
);

CREATE TABLE "countries" (
  "id" int(11) NOT NULL,
  "name" varchar(75) NOT NULL DEFAULT "",
  "alpha_2" char(2) NOT NULL DEFAULT "",
  "alpha_3" char(3) NOT NULL DEFAULT "",
  "capital" varchar(75) NOT NULL DEFAULT "",
  PRIMARY KEY ("id")
);
