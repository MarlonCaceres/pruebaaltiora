PGDMP                         |         
   db_altiora    13.2    13.2      �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            �           1262    66865 
   db_altiora    DATABASE     _   CREATE DATABASE db_altiora WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'en_US.UTF-8';
    DROP DATABASE db_altiora;
                postgres    false                        2615    66887    data    SCHEMA        CREATE SCHEMA data;
    DROP SCHEMA data;
                postgres    false            �            1255    66913 
   all_user()    FUNCTION     I  CREATE FUNCTION data.all_user() RETURNS TABLE(id bigint, name character varying, lastname character varying, identification character varying)
    LANGUAGE plpgsql ROWS 100
    AS $$
begin
	RETURN  QUERY
	SELECT 
		"ID" as Id,"NAME" as Name, "LASTNAME" as Lastname, "IDENTIFICATION" as Identification
	FROM data."User";
END;
$$;
    DROP FUNCTION data.all_user();
       data          postgres    false    5            �            1255    66909    delete_user(character varying)    FUNCTION     -  CREATE FUNCTION data.delete_user(id character varying) RETURNS TABLE(error integer, msm character varying)
    LANGUAGE plpgsql ROWS 100
    AS $$
begin
	delete from data."User"
	where "ID" = CAST(id AS bigint);
	
	RETURN  QUERY
	select 0 error, cast('Eliminación correcta' as varchar) msm;
END;
$$;
 6   DROP FUNCTION data.delete_user(id character varying);
       data          postgres    false    5            �            1255    66896    get_user_by_id(bigint)    FUNCTION     9  CREATE FUNCTION data.get_user_by_id(user_id bigint) RETURNS TABLE(name character varying, lastname character varying, identification character varying)
    LANGUAGE plpgsql ROWS 100
    AS $$
begin
	RETURN  QUERY
	SELECT 
		"NAME", "LASTNAME", "IDENTIFICATION"
	FROM data."User"
	where "ID" = USER_ID;
	
END;
$$;
 3   DROP FUNCTION data.get_user_by_id(user_id bigint);
       data          postgres    false    5            �            1255    66988 8   insert_order(character varying, json, character varying)    FUNCTION     ~  CREATE FUNCTION data.insert_order(code character varying, products json, date character varying) RETURNS TABLE(msm character varying)
    LANGUAGE plpgsql ROWS 100
    AS $$
	declare 
	longitud numeric;
begin
	--INSERT INTO data."Order"("CODE", "DATE")
--	VALUES (code, cast(date as timestamp));

	
	RETURN  QUERY
	select json_array_elements(replace(products,'\','')) msm;
END;
$$;
 `   DROP FUNCTION data.insert_order(code character varying, products json, date character varying);
       data          postgres    false    5            �            1255    66940 G   insert_product(character varying, character varying, character varying)    FUNCTION     �  CREATE FUNCTION data.insert_product(code character varying, name character varying, price character varying) RETURNS TABLE(error integer, msm character varying)
    LANGUAGE plpgsql ROWS 100
    AS $$
begin
	INSERT INTO data."Product"("CODE", "NAME", "PRICE")
	VALUES (code, name, cast(replace(price, ',', '.') as numeric(8,2)));
	
	RETURN  QUERY
	select 0 error, cast('Registro correcto' as varchar) msm;
END;
$$;
 l   DROP FUNCTION data.insert_product(code character varying, name character varying, price character varying);
       data          postgres    false    5            �            1255    66903 D   insert_user(character varying, character varying, character varying)    FUNCTION     �  CREATE FUNCTION data.insert_user(name character varying, lastname character varying, identification character varying) RETURNS TABLE(error integer, msm character varying)
    LANGUAGE plpgsql ROWS 100
    AS $$
begin
	INSERT INTO data."User"("NAME", "LASTNAME", "IDENTIFICATION")
	VALUES (name, lastname, identification);
	
	RETURN  QUERY
	select 0 error, cast('Registro correcto' as varchar) msm;
END;
$$;
 v   DROP FUNCTION data.insert_user(name character varying, lastname character varying, identification character varying);
       data          postgres    false    5            �            1255    66916 W   update_user(character varying, character varying, character varying, character varying)    FUNCTION     �  CREATE FUNCTION data.update_user(id character varying, name character varying, lastname character varying, identification character varying) RETURNS TABLE(error integer, msm character varying)
    LANGUAGE plpgsql ROWS 100
    AS $$
begin
	UPDATE data."User" set
	"NAME" = name, 
	"LASTNAME" = lastname, 
	"IDENTIFICATION" = identification
	WHERE "ID" = CAST(ID as bigint);
	RETURN  QUERY
	select 0 error, cast('Actualización correcta' as varchar) msm;
END;
$$;
 �   DROP FUNCTION data.update_user(id character varying, name character varying, lastname character varying, identification character varying);
       data          postgres    false    5            �            1255    66877    get_all_user()    FUNCTION       CREATE FUNCTION public.get_all_user() RETURNS TABLE(name character varying, lastname character varying, identification character varying)
    LANGUAGE plpgsql ROWS 100
    AS $$
begin
	RETURN  QUERY
	SELECT 
		"NAME", "LASTNAME", "IDENTIFICATION"
	FROM public."User";
	
END;
$$;
 %   DROP FUNCTION public.get_all_user();
       public          postgres    false            �            1259    66927    Order    TABLE     v   CREATE TABLE data."Order" (
    "ID" bigint NOT NULL,
    "CODE" character varying,
    "DATE" time with time zone
);
    DROP TABLE data."Order";
       data         heap    postgres    false    5            �            1259    66935    OrderDetail    TABLE     �   CREATE TABLE data."OrderDetail" (
    "ID" bigint NOT NULL,
    "PRODUCT_ID" bigint NOT NULL,
    "ORDER_ID" bigint NOT NULL
);
    DROP TABLE data."OrderDetail";
       data         heap    postgres    false    5            �            1259    66917    Product    TABLE     �   CREATE TABLE data."Product" (
    "ID" bigint NOT NULL,
    "CODE" character varying,
    "NAME" character varying,
    "PRICE" numeric
);
    DROP TABLE data."Product";
       data         heap    postgres    false    5            �            1259    66925    Product_ID_seq    SEQUENCE     �   ALTER TABLE data."Product" ALTER COLUMN "ID" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME data."Product_ID_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            data          postgres    false    204    5            �            1259    66888    User    TABLE     �   CREATE TABLE data."User" (
    "ID" bigint NOT NULL,
    "NAME" character varying,
    "LASTNAME" character varying,
    "IDENTIFICATION" character varying
);
    DROP TABLE data."User";
       data         heap    postgres    false    5            �            1259    66900    User_ID_seq    SEQUENCE     �   ALTER TABLE data."User" ALTER COLUMN "ID" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME data."User_ID_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            data          postgres    false    5    202            �            1259    66866    User    TABLE     �   CREATE TABLE public."User" (
    "ID" bigint NOT NULL,
    "NAME" character varying,
    "LASTNAME" character varying,
    "IDENTIFICATION" character varying
);
    DROP TABLE public."User";
       public         heap    postgres    false            �          0    66927    Order 
   TABLE DATA           5   COPY data."Order" ("ID", "CODE", "DATE") FROM stdin;
    data          postgres    false    206   	+       �          0    66935    OrderDetail 
   TABLE DATA           E   COPY data."OrderDetail" ("ID", "PRODUCT_ID", "ORDER_ID") FROM stdin;
    data          postgres    false    207   &+       �          0    66917    Product 
   TABLE DATA           @   COPY data."Product" ("ID", "CODE", "NAME", "PRICE") FROM stdin;
    data          postgres    false    204   C+       �          0    66888    User 
   TABLE DATA           J   COPY data."User" ("ID", "NAME", "LASTNAME", "IDENTIFICATION") FROM stdin;
    data          postgres    false    202   z+       �          0    66866    User 
   TABLE DATA           L   COPY public."User" ("ID", "NAME", "LASTNAME", "IDENTIFICATION") FROM stdin;
    public          postgres    false    201   �+       �           0    0    Product_ID_seq    SEQUENCE SET     <   SELECT pg_catalog.setval('data."Product_ID_seq"', 2, true);
          data          postgres    false    205            �           0    0    User_ID_seq    SEQUENCE SET     9   SELECT pg_catalog.setval('data."User_ID_seq"', 5, true);
          data          postgres    false    203            S           2606    66939    OrderDetail DETAIL_ORDER_pkey 
   CONSTRAINT     _   ALTER TABLE ONLY data."OrderDetail"
    ADD CONSTRAINT "DETAIL_ORDER_pkey" PRIMARY KEY ("ID");
 I   ALTER TABLE ONLY data."OrderDetail" DROP CONSTRAINT "DETAIL_ORDER_pkey";
       data            postgres    false    207            Q           2606    66934    Order Order_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY data."Order"
    ADD CONSTRAINT "Order_pkey" PRIMARY KEY ("ID");
 <   ALTER TABLE ONLY data."Order" DROP CONSTRAINT "Order_pkey";
       data            postgres    false    206            O           2606    66924    Product Product_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY data."Product"
    ADD CONSTRAINT "Product_pkey" PRIMARY KEY ("ID");
 @   ALTER TABLE ONLY data."Product" DROP CONSTRAINT "Product_pkey";
       data            postgres    false    204            M           2606    66895    User User_pkey 
   CONSTRAINT     P   ALTER TABLE ONLY data."User"
    ADD CONSTRAINT "User_pkey" PRIMARY KEY ("ID");
 :   ALTER TABLE ONLY data."User" DROP CONSTRAINT "User_pkey";
       data            postgres    false    202            K           2606    66879    User User_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public."User"
    ADD CONSTRAINT "User_pkey" PRIMARY KEY ("ID");
 <   ALTER TABLE ONLY public."User" DROP CONSTRAINT "User_pkey";
       public            postgres    false    201            �      x������ � �      �      x������ � �      �   '   x�3�2b�P�CNCS.#LA=S�=... �
      �   5   x�3��M,����tNLN-J-�44722�07�0�2��9��f�$"���qqq ��      �      x������ � �     