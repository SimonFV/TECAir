PGDMP         !                z            tecair    14.2    14.2 &    $           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            %           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            &           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            '           1262    16408    tecair    DATABASE     g   CREATE DATABASE tecair WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'Spanish_Costa Rica.1252';
    DROP DATABASE tecair;
                postgres    false            ?            1255    16526    get_planes()    FUNCTION     ?   CREATE FUNCTION public.get_planes() RETURNS TABLE(airplane_license text, model text)
    LANGUAGE sql
    AS $$SELECT airplane_license,model FROM plane WHERE plane.status = 'Free';$$;
 #   DROP FUNCTION public.get_planes();
       public          postgres    false            ?            1255    16533    get_rutes()    FUNCTION     ?   CREATE FUNCTION public.get_rutes() RETURNS TABLE(id integer, departure text, scale text, arrival text)
    LANGUAGE sql
    AS $$
SELECT * FROM rute;
$$;
 "   DROP FUNCTION public.get_rutes();
       public          postgres    false            ?            1255    16538    login(integer, text)    FUNCTION     P  CREATE FUNCTION public.login(ssn_in integer, password_in text) RETURNS text
    LANGUAGE sql
    AS $$select CASE
	WHEN ssn = ssn_in AND "password" = password_in THEN CONCAT(first_name, ' ', last_name_1)
	When ssn = ssn_in AND "password" != password_in THEN 'The password is incorrect'
	Else 'The user doesnt exist'
END
from "user";$$;
 >   DROP FUNCTION public.login(ssn_in integer, password_in text);
       public          postgres    false            ?            1255    16530    new_id(integer, integer)    FUNCTION     ?   CREATE FUNCTION public.new_id(number_in integer, mile_in integer) RETURNS void
    LANGUAGE sql
    AS $$Insert Into "id"("number", mile) Values(number_in, mile_in);$$;
 A   DROP FUNCTION public.new_id(number_in integer, mile_in integer);
       public          postgres    false            ?            1255    16528    new_plane(text, integer, text)    FUNCTION     ?   CREATE FUNCTION public.new_plane(airplane_license_in text, capacity_in integer, model_in text) RETURNS void
    LANGUAGE sql
    AS $$INSERT INTO plane(airplane_license, capacity, model) VALUES (airplane_license_in, capacity_in, model_in);$$;
 ^   DROP FUNCTION public.new_plane(airplane_license_in text, capacity_in integer, model_in text);
       public          postgres    false            ?            1255    16532 #   new_rute(integer, text, text, text)    FUNCTION     ?   CREATE FUNCTION public.new_rute(id_in integer, departure_in text, scale_in text, arrival_in text) RETURNS void
    LANGUAGE sql
    AS $$Insert into rute ("id", departure, "scale", arrival) 
values(id_in, departure_in, scale_in, arrival_in);$$;
 a   DROP FUNCTION public.new_rute(id_in integer, departure_in text, scale_in text, arrival_in text);
       public          postgres    false            ?            1255    16536 G   new_user(integer, integer, text, text, text, integer, text, text, text)    FUNCTION     <  CREATE FUNCTION public.new_user(ssn_in integer, schoolid_in integer, first_name_in text, last_name_1_in text, last_name_2_in text, phone_in integer, email_in text, university_in text, password_in text) RETURNS void
    LANGUAGE sql
    AS $$INSERT INTO "user"(ssn, schoolid,first_name, last_name_1, last_name_2, 
                   phone, email, university, "password") 
                   VALUES (ssn_in, schoolid_in,first_name_in, last_name_1_in,
                           last_name_2_in, phone_in, email_in, 
                           university_in, password_in);$$;
 ?   DROP FUNCTION public.new_user(ssn_in integer, schoolid_in integer, first_name_in text, last_name_1_in text, last_name_2_in text, phone_in integer, email_in text, university_in text, password_in text);
       public          postgres    false            ?            1259    16478    baggage    TABLE     ?   CREATE TABLE public.baggage (
    uniqueid integer NOT NULL,
    ssn integer NOT NULL,
    weight integer NOT NULL,
    color text NOT NULL
);
    DROP TABLE public.baggage;
       public         heap    postgres    false            ?            1259    16490    book    TABLE     o   CREATE TABLE public.book (
    ssn integer NOT NULL,
    id_flight integer NOT NULL,
    seat text NOT NULL
);
    DROP TABLE public.book;
       public         heap    postgres    false            ?            1259    16435    flight    TABLE     ?   CREATE TABLE public.flight (
    id integer NOT NULL,
    airplane_license text NOT NULL,
    id_rute integer NOT NULL,
    gate text NOT NULL,
    schedule text NOT NULL,
    status text DEFAULT 'In time'::text NOT NULL,
    deals integer
);
    DROP TABLE public.flight;
       public         heap    postgres    false            ?            1259    16409    plane    TABLE     ?   CREATE TABLE public.plane (
    airplane_license text NOT NULL,
    capacity integer NOT NULL,
    model text NOT NULL,
    status text DEFAULT 'Free'::text NOT NULL
);
    DROP TABLE public.plane;
       public         heap    postgres    false            ?            1259    16416    rute    TABLE     ~   CREATE TABLE public.rute (
    id integer NOT NULL,
    departure text NOT NULL,
    scale text,
    arrival text NOT NULL
);
    DROP TABLE public.rute;
       public         heap    postgres    false            ?            1259    16461    schoolid    TABLE     Y   CREATE TABLE public.schoolid (
    number integer NOT NULL,
    mile integer NOT NULL
);
    DROP TABLE public.schoolid;
       public         heap    postgres    false            ?            1259    16466    user    TABLE       CREATE TABLE public."user" (
    ssn integer NOT NULL,
    schoolid integer,
    first_name text NOT NULL,
    last_name_1 text NOT NULL,
    last_name_2 text NOT NULL,
    phone integer NOT NULL,
    email text NOT NULL,
    university text,
    password text NOT NULL
);
    DROP TABLE public."user";
       public         heap    postgres    false                       0    16478    baggage 
   TABLE DATA           ?   COPY public.baggage (uniqueid, ssn, weight, color) FROM stdin;
    public          postgres    false    214   d0       !          0    16490    book 
   TABLE DATA           4   COPY public.book (ssn, id_flight, seat) FROM stdin;
    public          postgres    false    215   ?0                 0    16435    flight 
   TABLE DATA           ^   COPY public.flight (id, airplane_license, id_rute, gate, schedule, status, deals) FROM stdin;
    public          postgres    false    211   ?0                 0    16409    plane 
   TABLE DATA           J   COPY public.plane (airplane_license, capacity, model, status) FROM stdin;
    public          postgres    false    209   ?0                 0    16416    rute 
   TABLE DATA           =   COPY public.rute (id, departure, scale, arrival) FROM stdin;
    public          postgres    false    210   ?0                 0    16461    schoolid 
   TABLE DATA           0   COPY public.schoolid (number, mile) FROM stdin;
    public          postgres    false    212   %1                 0    16466    user 
   TABLE DATA           y   COPY public."user" (ssn, schoolid, first_name, last_name_1, last_name_2, phone, email, university, password) FROM stdin;
    public          postgres    false    213   Q1       ?           2606    16484    baggage baggage_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY public.baggage
    ADD CONSTRAINT baggage_pkey PRIMARY KEY (uniqueid);
 >   ALTER TABLE ONLY public.baggage DROP CONSTRAINT baggage_pkey;
       public            postgres    false    214            ?           2606    16496    book book_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY public.book
    ADD CONSTRAINT book_pkey PRIMARY KEY (ssn, id_flight);
 8   ALTER TABLE ONLY public.book DROP CONSTRAINT book_pkey;
       public            postgres    false    215    215            ?           2606    16453    flight flight_pkey 
   CONSTRAINT     P   ALTER TABLE ONLY public.flight
    ADD CONSTRAINT flight_pkey PRIMARY KEY (id);
 <   ALTER TABLE ONLY public.flight DROP CONSTRAINT flight_pkey;
       public            postgres    false    211            ?           2606    16465    schoolid id_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public.schoolid
    ADD CONSTRAINT id_pkey PRIMARY KEY (number);
 :   ALTER TABLE ONLY public.schoolid DROP CONSTRAINT id_pkey;
       public            postgres    false    212            }           2606    16415    plane plane_pkey 
   CONSTRAINT     \   ALTER TABLE ONLY public.plane
    ADD CONSTRAINT plane_pkey PRIMARY KEY (airplane_license);
 :   ALTER TABLE ONLY public.plane DROP CONSTRAINT plane_pkey;
       public            postgres    false    209                       2606    16422    rute rute_pkey 
   CONSTRAINT     L   ALTER TABLE ONLY public.rute
    ADD CONSTRAINT rute_pkey PRIMARY KEY (id);
 8   ALTER TABLE ONLY public.rute DROP CONSTRAINT rute_pkey;
       public            postgres    false    210            ?           2606    16472    user user_pkey 
   CONSTRAINT     O   ALTER TABLE ONLY public."user"
    ADD CONSTRAINT user_pkey PRIMARY KEY (ssn);
 :   ALTER TABLE ONLY public."user" DROP CONSTRAINT user_pkey;
       public            postgres    false    213            ?           2606    16485    baggage baggage_ssn_fkey    FK CONSTRAINT     u   ALTER TABLE ONLY public.baggage
    ADD CONSTRAINT baggage_ssn_fkey FOREIGN KEY (ssn) REFERENCES public."user"(ssn);
 B   ALTER TABLE ONLY public.baggage DROP CONSTRAINT baggage_ssn_fkey;
       public          postgres    false    214    3205    213            ?           2606    16497    book book_id_flight_fkey    FK CONSTRAINT     z   ALTER TABLE ONLY public.book
    ADD CONSTRAINT book_id_flight_fkey FOREIGN KEY (id_flight) REFERENCES public.flight(id);
 B   ALTER TABLE ONLY public.book DROP CONSTRAINT book_id_flight_fkey;
       public          postgres    false    3201    215    211            ?           2606    16502    book book_ssn_fkey    FK CONSTRAINT     o   ALTER TABLE ONLY public.book
    ADD CONSTRAINT book_ssn_fkey FOREIGN KEY (ssn) REFERENCES public."user"(ssn);
 <   ALTER TABLE ONLY public.book DROP CONSTRAINT book_ssn_fkey;
       public          postgres    false    3205    213    215            ?           2606    16442 #   flight flight_airplane_license_fkey    FK CONSTRAINT     ?   ALTER TABLE ONLY public.flight
    ADD CONSTRAINT flight_airplane_license_fkey FOREIGN KEY (airplane_license) REFERENCES public.plane(airplane_license);
 M   ALTER TABLE ONLY public.flight DROP CONSTRAINT flight_airplane_license_fkey;
       public          postgres    false    211    3197    209            ?           2606    16454    flight flight_id_rute_fkey    FK CONSTRAINT     ?   ALTER TABLE ONLY public.flight
    ADD CONSTRAINT flight_id_rute_fkey FOREIGN KEY (id_rute) REFERENCES public.rute(id) NOT VALID;
 D   ALTER TABLE ONLY public.flight DROP CONSTRAINT flight_id_rute_fkey;
       public          postgres    false    211    3199    210            ?           2606    16473    user user_id_fkey    FK CONSTRAINT     z   ALTER TABLE ONLY public."user"
    ADD CONSTRAINT user_id_fkey FOREIGN KEY (schoolid) REFERENCES public.schoolid(number);
 =   ALTER TABLE ONLY public."user" DROP CONSTRAINT user_id_fkey;
       public          postgres    false    212    213    3203                   x?????? ? ?      !      x?????? ? ?            x?????? ? ?         *   x?34*,/N16?45?t?O??KW0767?t+JM?????? ?&?             x?3?N?S??/>????7317?+F??? \??            x?32043?04?0?440?????? &?P         R   x?3?42043?04?0?t/J-I?H????O??O?,??+I-??442?L?H?-?IuH-.)M?LJ$?%q)??	W? ??n     