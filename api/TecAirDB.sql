PGDMP     6    2                z            TecAirDB    14.2    14.2 N    h           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            i           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            j           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            k           1262    16842    TecAirDB    DATABASE     k   CREATE DATABASE "TecAirDB" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'Spanish_Costa Rica.1252';
    DROP DATABASE "TecAirDB";
                postgres    false            �            1259    16877    AspNetRoleClaims    TABLE     �   CREATE TABLE public."AspNetRoleClaims" (
    "Id" integer NOT NULL,
    "RoleId" integer NOT NULL,
    "ClaimType" text,
    "ClaimValue" text
);
 &   DROP TABLE public."AspNetRoleClaims";
       public         heap    postgres    false            �            1259    16876    AspNetRoleClaims_Id_seq    SEQUENCE     �   ALTER TABLE public."AspNetRoleClaims" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."AspNetRoleClaims_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    216            �            1259    16849    AspNetRoles    TABLE     �   CREATE TABLE public."AspNetRoles" (
    "Id" integer NOT NULL,
    "Name" character varying(256),
    "NormalizedName" character varying(256),
    "ConcurrencyStamp" text
);
 !   DROP TABLE public."AspNetRoles";
       public         heap    postgres    false            �            1259    16848    AspNetRoles_Id_seq    SEQUENCE     �   ALTER TABLE public."AspNetRoles" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."AspNetRoles_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    211            �            1259    16921    AspNetUserClaims    TABLE     �   CREATE TABLE public."AspNetUserClaims" (
    "Id" integer NOT NULL,
    "UserId" integer NOT NULL,
    "ClaimType" text,
    "ClaimValue" text
);
 &   DROP TABLE public."AspNetUserClaims";
       public         heap    postgres    false            �            1259    16920    AspNetUserClaims_Id_seq    SEQUENCE     �   ALTER TABLE public."AspNetUserClaims" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."AspNetUserClaims_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    221            �            1259    16933    AspNetUserLogins    TABLE     �   CREATE TABLE public."AspNetUserLogins" (
    "LoginProvider" text NOT NULL,
    "ProviderKey" text NOT NULL,
    "ProviderDisplayName" text,
    "UserId" integer NOT NULL
);
 &   DROP TABLE public."AspNetUserLogins";
       public         heap    postgres    false            �            1259    16945    AspNetUserRoles    TABLE     h   CREATE TABLE public."AspNetUserRoles" (
    "UserId" integer NOT NULL,
    "RoleId" integer NOT NULL
);
 %   DROP TABLE public."AspNetUserRoles";
       public         heap    postgres    false            �            1259    16960    AspNetUserTokens    TABLE     �   CREATE TABLE public."AspNetUserTokens" (
    "UserId" integer NOT NULL,
    "LoginProvider" text NOT NULL,
    "Name" text NOT NULL,
    "Value" text
);
 &   DROP TABLE public."AspNetUserTokens";
       public         heap    postgres    false            �            1259    16908    AspNetUsers    TABLE     �  CREATE TABLE public."AspNetUsers" (
    "Id" integer NOT NULL,
    ssn integer NOT NULL,
    first_name text NOT NULL,
    last_name_1 text NOT NULL,
    last_name_2 text NOT NULL,
    university text,
    schoolid integer,
    "UserName" character varying(256),
    "NormalizedUserName" character varying(256),
    "Email" character varying(256),
    "NormalizedEmail" character varying(256),
    "EmailConfirmed" boolean NOT NULL,
    "PasswordHash" text,
    "SecurityStamp" text,
    "ConcurrencyStamp" text,
    "PhoneNumber" text,
    "PhoneNumberConfirmed" boolean NOT NULL,
    "TwoFactorEnabled" boolean NOT NULL,
    "LockoutEnd" timestamp with time zone,
    "LockoutEnabled" boolean NOT NULL,
    "AccessFailedCount" integer NOT NULL
);
 !   DROP TABLE public."AspNetUsers";
       public         heap    postgres    false            �            1259    16907    AspNetUsers_Id_seq    SEQUENCE     �   ALTER TABLE public."AspNetUsers" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."AspNetUsers_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    219            �            1259    16843    __EFMigrationsHistory    TABLE     �   CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);
 +   DROP TABLE public."__EFMigrationsHistory";
       public         heap    postgres    false            �            1259    16972    baggage    TABLE     �   CREATE TABLE public.baggage (
    uniqueid integer NOT NULL,
    ssn integer NOT NULL,
    weight integer NOT NULL,
    color text NOT NULL
);
    DROP TABLE public.baggage;
       public         heap    postgres    false            �            1259    16984    book    TABLE     o   CREATE TABLE public.book (
    ssn integer NOT NULL,
    id_flight integer NOT NULL,
    seat text NOT NULL
);
    DROP TABLE public.book;
       public         heap    postgres    false            �            1259    16889    flight    TABLE     �   CREATE TABLE public.flight (
    id integer NOT NULL,
    airplane_license text NOT NULL,
    id_rute integer NOT NULL,
    gate text NOT NULL,
    schedule text NOT NULL,
    status text DEFAULT 'In time'::text NOT NULL,
    deals integer
);
    DROP TABLE public.flight;
       public         heap    postgres    false            �            1259    16856    plane    TABLE     �   CREATE TABLE public.plane (
    airplane_license text NOT NULL,
    capacity integer NOT NULL,
    model text NOT NULL,
    status text DEFAULT 'Free'::text NOT NULL
);
    DROP TABLE public.plane;
       public         heap    postgres    false            �            1259    16864    rute    TABLE     ~   CREATE TABLE public.rute (
    id integer NOT NULL,
    departure text NOT NULL,
    scale text,
    arrival text NOT NULL
);
    DROP TABLE public.rute;
       public         heap    postgres    false            �            1259    16871    schoolid    TABLE     Y   CREATE TABLE public.schoolid (
    number integer NOT NULL,
    mile integer NOT NULL
);
    DROP TABLE public.schoolid;
       public         heap    postgres    false            [          0    16877    AspNetRoleClaims 
   TABLE DATA           W   COPY public."AspNetRoleClaims" ("Id", "RoleId", "ClaimType", "ClaimValue") FROM stdin;
    public          postgres    false    216   �a       V          0    16849    AspNetRoles 
   TABLE DATA           [   COPY public."AspNetRoles" ("Id", "Name", "NormalizedName", "ConcurrencyStamp") FROM stdin;
    public          postgres    false    211   �a       `          0    16921    AspNetUserClaims 
   TABLE DATA           W   COPY public."AspNetUserClaims" ("Id", "UserId", "ClaimType", "ClaimValue") FROM stdin;
    public          postgres    false    221   �a       a          0    16933    AspNetUserLogins 
   TABLE DATA           m   COPY public."AspNetUserLogins" ("LoginProvider", "ProviderKey", "ProviderDisplayName", "UserId") FROM stdin;
    public          postgres    false    222   �a       b          0    16945    AspNetUserRoles 
   TABLE DATA           ?   COPY public."AspNetUserRoles" ("UserId", "RoleId") FROM stdin;
    public          postgres    false    223   �a       c          0    16960    AspNetUserTokens 
   TABLE DATA           X   COPY public."AspNetUserTokens" ("UserId", "LoginProvider", "Name", "Value") FROM stdin;
    public          postgres    false    224   b       ^          0    16908    AspNetUsers 
   TABLE DATA           c  COPY public."AspNetUsers" ("Id", ssn, first_name, last_name_1, last_name_2, university, schoolid, "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumber", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled", "AccessFailedCount") FROM stdin;
    public          postgres    false    219   8b       T          0    16843    __EFMigrationsHistory 
   TABLE DATA           R   COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
    public          postgres    false    209   Ub       d          0    16972    baggage 
   TABLE DATA           ?   COPY public.baggage (uniqueid, ssn, weight, color) FROM stdin;
    public          postgres    false    225   �b       e          0    16984    book 
   TABLE DATA           4   COPY public.book (ssn, id_flight, seat) FROM stdin;
    public          postgres    false    226   �b       \          0    16889    flight 
   TABLE DATA           ^   COPY public.flight (id, airplane_license, id_rute, gate, schedule, status, deals) FROM stdin;
    public          postgres    false    217   �b       W          0    16856    plane 
   TABLE DATA           J   COPY public.plane (airplane_license, capacity, model, status) FROM stdin;
    public          postgres    false    212   �b       X          0    16864    rute 
   TABLE DATA           =   COPY public.rute (id, departure, scale, arrival) FROM stdin;
    public          postgres    false    213   	c       Y          0    16871    schoolid 
   TABLE DATA           0   COPY public.schoolid (number, mile) FROM stdin;
    public          postgres    false    214   &c       l           0    0    AspNetRoleClaims_Id_seq    SEQUENCE SET     H   SELECT pg_catalog.setval('public."AspNetRoleClaims_Id_seq"', 1, false);
          public          postgres    false    215            m           0    0    AspNetRoles_Id_seq    SEQUENCE SET     C   SELECT pg_catalog.setval('public."AspNetRoles_Id_seq"', 1, false);
          public          postgres    false    210            n           0    0    AspNetUserClaims_Id_seq    SEQUENCE SET     H   SELECT pg_catalog.setval('public."AspNetUserClaims_Id_seq"', 1, false);
          public          postgres    false    220            o           0    0    AspNetUsers_Id_seq    SEQUENCE SET     C   SELECT pg_catalog.setval('public."AspNetUsers_Id_seq"', 1, false);
          public          postgres    false    218            �           2606    16883 $   AspNetRoleClaims PK_AspNetRoleClaims 
   CONSTRAINT     h   ALTER TABLE ONLY public."AspNetRoleClaims"
    ADD CONSTRAINT "PK_AspNetRoleClaims" PRIMARY KEY ("Id");
 R   ALTER TABLE ONLY public."AspNetRoleClaims" DROP CONSTRAINT "PK_AspNetRoleClaims";
       public            postgres    false    216            �           2606    16855    AspNetRoles PK_AspNetRoles 
   CONSTRAINT     ^   ALTER TABLE ONLY public."AspNetRoles"
    ADD CONSTRAINT "PK_AspNetRoles" PRIMARY KEY ("Id");
 H   ALTER TABLE ONLY public."AspNetRoles" DROP CONSTRAINT "PK_AspNetRoles";
       public            postgres    false    211            �           2606    16927 $   AspNetUserClaims PK_AspNetUserClaims 
   CONSTRAINT     h   ALTER TABLE ONLY public."AspNetUserClaims"
    ADD CONSTRAINT "PK_AspNetUserClaims" PRIMARY KEY ("Id");
 R   ALTER TABLE ONLY public."AspNetUserClaims" DROP CONSTRAINT "PK_AspNetUserClaims";
       public            postgres    false    221            �           2606    16939 $   AspNetUserLogins PK_AspNetUserLogins 
   CONSTRAINT     �   ALTER TABLE ONLY public."AspNetUserLogins"
    ADD CONSTRAINT "PK_AspNetUserLogins" PRIMARY KEY ("LoginProvider", "ProviderKey");
 R   ALTER TABLE ONLY public."AspNetUserLogins" DROP CONSTRAINT "PK_AspNetUserLogins";
       public            postgres    false    222    222            �           2606    16949 "   AspNetUserRoles PK_AspNetUserRoles 
   CONSTRAINT     t   ALTER TABLE ONLY public."AspNetUserRoles"
    ADD CONSTRAINT "PK_AspNetUserRoles" PRIMARY KEY ("UserId", "RoleId");
 P   ALTER TABLE ONLY public."AspNetUserRoles" DROP CONSTRAINT "PK_AspNetUserRoles";
       public            postgres    false    223    223            �           2606    16966 $   AspNetUserTokens PK_AspNetUserTokens 
   CONSTRAINT     �   ALTER TABLE ONLY public."AspNetUserTokens"
    ADD CONSTRAINT "PK_AspNetUserTokens" PRIMARY KEY ("UserId", "LoginProvider", "Name");
 R   ALTER TABLE ONLY public."AspNetUserTokens" DROP CONSTRAINT "PK_AspNetUserTokens";
       public            postgres    false    224    224    224            �           2606    16914    AspNetUsers PK_AspNetUsers 
   CONSTRAINT     ^   ALTER TABLE ONLY public."AspNetUsers"
    ADD CONSTRAINT "PK_AspNetUsers" PRIMARY KEY ("Id");
 H   ALTER TABLE ONLY public."AspNetUsers" DROP CONSTRAINT "PK_AspNetUsers";
       public            postgres    false    219            �           2606    16847 .   __EFMigrationsHistory PK___EFMigrationsHistory 
   CONSTRAINT     {   ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");
 \   ALTER TABLE ONLY public."__EFMigrationsHistory" DROP CONSTRAINT "PK___EFMigrationsHistory";
       public            postgres    false    209            �           2606    16896    flight PK_flight 
   CONSTRAINT     P   ALTER TABLE ONLY public.flight
    ADD CONSTRAINT "PK_flight" PRIMARY KEY (id);
 <   ALTER TABLE ONLY public.flight DROP CONSTRAINT "PK_flight";
       public            postgres    false    217            �           2606    16870    rute PK_rute 
   CONSTRAINT     L   ALTER TABLE ONLY public.rute
    ADD CONSTRAINT "PK_rute" PRIMARY KEY (id);
 8   ALTER TABLE ONLY public.rute DROP CONSTRAINT "PK_rute";
       public            postgres    false    213            �           2606    16978    baggage baggage_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY public.baggage
    ADD CONSTRAINT baggage_pkey PRIMARY KEY (uniqueid);
 >   ALTER TABLE ONLY public.baggage DROP CONSTRAINT baggage_pkey;
       public            postgres    false    225            �           2606    16990    book book_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY public.book
    ADD CONSTRAINT book_pkey PRIMARY KEY (ssn, id_flight);
 8   ALTER TABLE ONLY public.book DROP CONSTRAINT book_pkey;
       public            postgres    false    226    226            �           2606    16875    schoolid id_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public.schoolid
    ADD CONSTRAINT id_pkey PRIMARY KEY (number);
 :   ALTER TABLE ONLY public.schoolid DROP CONSTRAINT id_pkey;
       public            postgres    false    214            �           2606    16863    plane plane_pkey 
   CONSTRAINT     \   ALTER TABLE ONLY public.plane
    ADD CONSTRAINT plane_pkey PRIMARY KEY (airplane_license);
 :   ALTER TABLE ONLY public.plane DROP CONSTRAINT plane_pkey;
       public            postgres    false    212            �           1259    17006 
   EmailIndex    INDEX     S   CREATE INDEX "EmailIndex" ON public."AspNetUsers" USING btree ("NormalizedEmail");
     DROP INDEX public."EmailIndex";
       public            postgres    false    219            �           1259    17001    IX_AspNetRoleClaims_RoleId    INDEX     _   CREATE INDEX "IX_AspNetRoleClaims_RoleId" ON public."AspNetRoleClaims" USING btree ("RoleId");
 0   DROP INDEX public."IX_AspNetRoleClaims_RoleId";
       public            postgres    false    216            �           1259    17003    IX_AspNetUserClaims_UserId    INDEX     _   CREATE INDEX "IX_AspNetUserClaims_UserId" ON public."AspNetUserClaims" USING btree ("UserId");
 0   DROP INDEX public."IX_AspNetUserClaims_UserId";
       public            postgres    false    221            �           1259    17004    IX_AspNetUserLogins_UserId    INDEX     _   CREATE INDEX "IX_AspNetUserLogins_UserId" ON public."AspNetUserLogins" USING btree ("UserId");
 0   DROP INDEX public."IX_AspNetUserLogins_UserId";
       public            postgres    false    222            �           1259    17005    IX_AspNetUserRoles_RoleId    INDEX     ]   CREATE INDEX "IX_AspNetUserRoles_RoleId" ON public."AspNetUserRoles" USING btree ("RoleId");
 /   DROP INDEX public."IX_AspNetUserRoles_RoleId";
       public            postgres    false    223            �           1259    17007    IX_AspNetUsers_schoolid    INDEX     W   CREATE INDEX "IX_AspNetUsers_schoolid" ON public."AspNetUsers" USING btree (schoolid);
 -   DROP INDEX public."IX_AspNetUsers_schoolid";
       public            postgres    false    219            �           1259    17009    IX_baggage_ssn    INDEX     C   CREATE INDEX "IX_baggage_ssn" ON public.baggage USING btree (ssn);
 $   DROP INDEX public."IX_baggage_ssn";
       public            postgres    false    225            �           1259    17010    IX_book_id_flight    INDEX     I   CREATE INDEX "IX_book_id_flight" ON public.book USING btree (id_flight);
 '   DROP INDEX public."IX_book_id_flight";
       public            postgres    false    226            �           1259    17011    IX_flight_airplane_license    INDEX     [   CREATE INDEX "IX_flight_airplane_license" ON public.flight USING btree (airplane_license);
 0   DROP INDEX public."IX_flight_airplane_license";
       public            postgres    false    217            �           1259    17012    IX_flight_id_rute    INDEX     I   CREATE INDEX "IX_flight_id_rute" ON public.flight USING btree (id_rute);
 '   DROP INDEX public."IX_flight_id_rute";
       public            postgres    false    217            �           1259    17002    RoleNameIndex    INDEX     \   CREATE UNIQUE INDEX "RoleNameIndex" ON public."AspNetRoles" USING btree ("NormalizedName");
 #   DROP INDEX public."RoleNameIndex";
       public            postgres    false    211            �           1259    17008    UserNameIndex    INDEX     `   CREATE UNIQUE INDEX "UserNameIndex" ON public."AspNetUsers" USING btree ("NormalizedUserName");
 #   DROP INDEX public."UserNameIndex";
       public            postgres    false    219            �           2606    16884 7   AspNetRoleClaims FK_AspNetRoleClaims_AspNetRoles_RoleId    FK CONSTRAINT     �   ALTER TABLE ONLY public."AspNetRoleClaims"
    ADD CONSTRAINT "FK_AspNetRoleClaims_AspNetRoles_RoleId" FOREIGN KEY ("RoleId") REFERENCES public."AspNetRoles"("Id") ON DELETE CASCADE;
 e   ALTER TABLE ONLY public."AspNetRoleClaims" DROP CONSTRAINT "FK_AspNetRoleClaims_AspNetRoles_RoleId";
       public          postgres    false    3224    216    211            �           2606    16928 7   AspNetUserClaims FK_AspNetUserClaims_AspNetUsers_UserId    FK CONSTRAINT     �   ALTER TABLE ONLY public."AspNetUserClaims"
    ADD CONSTRAINT "FK_AspNetUserClaims_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES public."AspNetUsers"("Id") ON DELETE CASCADE;
 e   ALTER TABLE ONLY public."AspNetUserClaims" DROP CONSTRAINT "FK_AspNetUserClaims_AspNetUsers_UserId";
       public          postgres    false    219    3242    221            �           2606    16940 7   AspNetUserLogins FK_AspNetUserLogins_AspNetUsers_UserId    FK CONSTRAINT     �   ALTER TABLE ONLY public."AspNetUserLogins"
    ADD CONSTRAINT "FK_AspNetUserLogins_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES public."AspNetUsers"("Id") ON DELETE CASCADE;
 e   ALTER TABLE ONLY public."AspNetUserLogins" DROP CONSTRAINT "FK_AspNetUserLogins_AspNetUsers_UserId";
       public          postgres    false    222    3242    219            �           2606    16950 5   AspNetUserRoles FK_AspNetUserRoles_AspNetRoles_RoleId    FK CONSTRAINT     �   ALTER TABLE ONLY public."AspNetUserRoles"
    ADD CONSTRAINT "FK_AspNetUserRoles_AspNetRoles_RoleId" FOREIGN KEY ("RoleId") REFERENCES public."AspNetRoles"("Id") ON DELETE CASCADE;
 c   ALTER TABLE ONLY public."AspNetUserRoles" DROP CONSTRAINT "FK_AspNetUserRoles_AspNetRoles_RoleId";
       public          postgres    false    223    3224    211            �           2606    16955 5   AspNetUserRoles FK_AspNetUserRoles_AspNetUsers_UserId    FK CONSTRAINT     �   ALTER TABLE ONLY public."AspNetUserRoles"
    ADD CONSTRAINT "FK_AspNetUserRoles_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES public."AspNetUsers"("Id") ON DELETE CASCADE;
 c   ALTER TABLE ONLY public."AspNetUserRoles" DROP CONSTRAINT "FK_AspNetUserRoles_AspNetUsers_UserId";
       public          postgres    false    219    223    3242            �           2606    16967 7   AspNetUserTokens FK_AspNetUserTokens_AspNetUsers_UserId    FK CONSTRAINT     �   ALTER TABLE ONLY public."AspNetUserTokens"
    ADD CONSTRAINT "FK_AspNetUserTokens_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES public."AspNetUsers"("Id") ON DELETE CASCADE;
 e   ALTER TABLE ONLY public."AspNetUserTokens" DROP CONSTRAINT "FK_AspNetUserTokens_AspNetUsers_UserId";
       public          postgres    false    219    3242    224            �           2606    16979    baggage baggage_ssn_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.baggage
    ADD CONSTRAINT baggage_ssn_fkey FOREIGN KEY (ssn) REFERENCES public."AspNetUsers"("Id") ON DELETE RESTRICT;
 B   ALTER TABLE ONLY public.baggage DROP CONSTRAINT baggage_ssn_fkey;
       public          postgres    false    225    219    3242            �           2606    16991    book book_id_flight_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.book
    ADD CONSTRAINT book_id_flight_fkey FOREIGN KEY (id_flight) REFERENCES public.flight(id) ON DELETE RESTRICT;
 B   ALTER TABLE ONLY public.book DROP CONSTRAINT book_id_flight_fkey;
       public          postgres    false    226    3238    217            �           2606    16996    book book_ssn_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.book
    ADD CONSTRAINT book_ssn_fkey FOREIGN KEY (ssn) REFERENCES public."AspNetUsers"("Id") ON DELETE RESTRICT;
 <   ALTER TABLE ONLY public.book DROP CONSTRAINT book_ssn_fkey;
       public          postgres    false    219    3242    226            �           2606    16897 #   flight flight_airplane_license_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.flight
    ADD CONSTRAINT flight_airplane_license_fkey FOREIGN KEY (airplane_license) REFERENCES public.plane(airplane_license) ON DELETE RESTRICT;
 M   ALTER TABLE ONLY public.flight DROP CONSTRAINT flight_airplane_license_fkey;
       public          postgres    false    212    3227    217            �           2606    16902    flight flight_id_rute_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.flight
    ADD CONSTRAINT flight_id_rute_fkey FOREIGN KEY (id_rute) REFERENCES public.rute(id) ON DELETE RESTRICT;
 D   ALTER TABLE ONLY public.flight DROP CONSTRAINT flight_id_rute_fkey;
       public          postgres    false    217    3229    213            �           2606    16915    AspNetUsers user_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."AspNetUsers"
    ADD CONSTRAINT user_id_fkey FOREIGN KEY (schoolid) REFERENCES public.schoolid(number) ON DELETE RESTRICT;
 D   ALTER TABLE ONLY public."AspNetUsers" DROP CONSTRAINT user_id_fkey;
       public          postgres    false    219    214    3231            [      x������ � �      V      x������ � �      `      x������ � �      a      x������ � �      b      x������ � �      c      x������ � �      ^      x������ � �      T   0   x�320220120�4002����,�L�q.JM,I�4�3�3����� �	�      d      x������ � �      e      x������ � �      \      x������ � �      W      x������ � �      X      x������ � �      Y      x������ � �     