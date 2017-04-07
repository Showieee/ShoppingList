--
-- PostgreSQL database dump
--

-- Dumped from database version 9.6.2
-- Dumped by pg_dump version 9.6.2

-- Started on 2017-04-04 17:57:27

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SET check_function_bodies = false;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 2159 (class 1262 OID 16393)
-- Name: ShoppingList; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE "ShoppingList" WITH TEMPLATE = template0 ENCODING = 'UTF8' LC_COLLATE = 'English_United States.1252' LC_CTYPE = 'English_United States.1252';


ALTER DATABASE "ShoppingList" OWNER TO postgres;

\connect "ShoppingList"

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SET check_function_bodies = false;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 1 (class 3079 OID 12387)
-- Name: plpgsql; Type: EXTENSION; Schema: -; Owner: 
--

CREATE EXTENSION IF NOT EXISTS plpgsql WITH SCHEMA pg_catalog;


--
-- TOC entry 2161 (class 0 OID 0)
-- Dependencies: 1
-- Name: EXTENSION plpgsql; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION plpgsql IS 'PL/pgSQL procedural language';


SET search_path = public, pg_catalog;

SET default_tablespace = '';

SET default_with_oids = false;

--
-- TOC entry 185 (class 1259 OID 16394)
-- Name: delivery_locations; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE delivery_locations (
    id integer NOT NULL,
    name character varying(250),
    address text
);


ALTER TABLE delivery_locations OWNER TO postgres;

--
-- TOC entry 188 (class 1259 OID 16640)
-- Name: login_info; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE login_info (
    id integer NOT NULL,
    username character varying(100) NOT NULL,
    password character varying(100) NOT NULL
);


ALTER TABLE login_info OWNER TO postgres;

--
-- TOC entry 187 (class 1259 OID 16638)
-- Name: login_info_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE login_info_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE login_info_id_seq OWNER TO postgres;

--
-- TOC entry 2162 (class 0 OID 0)
-- Dependencies: 187
-- Name: login_info_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE login_info_id_seq OWNED BY login_info.id;


--
-- TOC entry 191 (class 1259 OID 16663)
-- Name: product_requests; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE product_requests (
    id integer NOT NULL,
    item character varying(150),
    amount character varying(40),
    details text,
    site_id integer,
    fulfilled_by_driver integer,
    is_delivered boolean DEFAULT false NOT NULL
);


ALTER TABLE product_requests OWNER TO postgres;

--
-- TOC entry 190 (class 1259 OID 16661)
-- Name: product_requests_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE product_requests_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE product_requests_id_seq OWNER TO postgres;

--
-- TOC entry 2163 (class 0 OID 0)
-- Dependencies: 190
-- Name: product_requests_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE product_requests_id_seq OWNED BY product_requests.id;


--
-- TOC entry 186 (class 1259 OID 16416)
-- Name: site_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE site_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE site_id_seq OWNER TO postgres;

--
-- TOC entry 2164 (class 0 OID 0)
-- Dependencies: 186
-- Name: site_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE site_id_seq OWNED BY delivery_locations.id;


--
-- TOC entry 189 (class 1259 OID 16648)
-- Name: user_info; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE user_info (
    id integer NOT NULL,
    first_name character varying(100),
    last_name character varying(100),
    telephone character varying(15),
    is_driver boolean
);


ALTER TABLE user_info OWNER TO postgres;

--
-- TOC entry 2019 (class 2604 OID 16418)
-- Name: delivery_locations id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY delivery_locations ALTER COLUMN id SET DEFAULT nextval('site_id_seq'::regclass);


--
-- TOC entry 2020 (class 2604 OID 16643)
-- Name: login_info id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY login_info ALTER COLUMN id SET DEFAULT nextval('login_info_id_seq'::regclass);


--
-- TOC entry 2021 (class 2604 OID 16666)
-- Name: product_requests id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY product_requests ALTER COLUMN id SET DEFAULT nextval('product_requests_id_seq'::regclass);


--
-- TOC entry 2028 (class 2606 OID 16645)
-- Name: login_info pk_login_info; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY login_info
    ADD CONSTRAINT pk_login_info PRIMARY KEY (id);


--
-- TOC entry 2034 (class 2606 OID 16672)
-- Name: product_requests pk_request; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY product_requests
    ADD CONSTRAINT pk_request PRIMARY KEY (id);


--
-- TOC entry 2024 (class 2606 OID 16426)
-- Name: delivery_locations pk_site; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY delivery_locations
    ADD CONSTRAINT pk_site PRIMARY KEY (id);


--
-- TOC entry 2032 (class 2606 OID 16652)
-- Name: user_info pk_user; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY user_info
    ADD CONSTRAINT pk_user PRIMARY KEY (id);


--
-- TOC entry 2026 (class 2606 OID 16428)
-- Name: delivery_locations unique_name; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY delivery_locations
    ADD CONSTRAINT unique_name UNIQUE (name);


--
-- TOC entry 2030 (class 2606 OID 16647)
-- Name: login_info unique_username; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY login_info
    ADD CONSTRAINT unique_username UNIQUE (username);


--
-- TOC entry 2035 (class 2606 OID 16653)
-- Name: user_info fk_login_info; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY user_info
    ADD CONSTRAINT fk_login_info FOREIGN KEY (id) REFERENCES login_info(id) ON DELETE CASCADE;


--
-- TOC entry 2036 (class 2606 OID 16673)
-- Name: product_requests fk_site; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY product_requests
    ADD CONSTRAINT fk_site FOREIGN KEY (site_id) REFERENCES delivery_locations(id) ON DELETE CASCADE;


--
-- TOC entry 2037 (class 2606 OID 16678)
-- Name: product_requests fk_user_info; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY product_requests
    ADD CONSTRAINT fk_user_info FOREIGN KEY (fulfilled_by_driver) REFERENCES user_info(id) ON DELETE CASCADE;


-- Completed on 2017-04-04 17:57:27

--
-- PostgreSQL database dump complete
--

