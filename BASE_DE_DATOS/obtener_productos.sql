-- FUNCTION: schemasye.obtener_productos()

-- DROP FUNCTION IF EXISTS schemasye.obtener_productos();

CREATE OR REPLACE FUNCTION schemasye.obtener_productos(
	)
    RETURNS TABLE(idproducto integer, nombre character varying, precio double precision, cantidad integer, fecha_registro date, estado boolean) 
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$

BEGIN
    RETURN QUERY 
    SELECT p."idproducto", p."nombre", p."precio", p."cantidad", p."fecha_registro", p."estado"
    FROM schemasye."Producto" p
    WHERE p."estado" = TRUE
    ORDER BY p."idproducto" ASC;
END;
$BODY$;

ALTER FUNCTION schemasye.obtener_productos()
    OWNER TO postgres;
