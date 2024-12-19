-- FUNCTION: schemasye.obtener_producto_por_id(integer)

-- DROP FUNCTION IF EXISTS schemasye.obtener_producto_por_id(integer);

CREATE OR REPLACE FUNCTION schemasye.obtener_producto_por_id(
	p_idproducto integer)
    RETURNS TABLE(idproducto integer, nombre character varying, precio double precision, cantidad integer, fecha_registro date, estado boolean) 
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
BEGIN
    RETURN QUERY 
    SELECT p.idproducto, p.nombre, p.precio, p.cantidad, p.fecha_registro, p.estado
    FROM schemasye."Producto" p
    WHERE p.idproducto = p_idproducto;
END;
$BODY$;

ALTER FUNCTION schemasye.obtener_producto_por_id(integer)
    OWNER TO postgres;
