-- FUNCTION: schemasye.actualizar_producto(integer, character varying, double precision, integer, date, boolean)

-- DROP FUNCTION IF EXISTS schemasye.actualizar_producto(integer, character varying, double precision, integer, date, boolean);

CREATE OR REPLACE FUNCTION schemasye.actualizar_producto(
	p_idproducto integer,
	p_nombre character varying,
	p_precio double precision,
	p_cantidad integer,
	p_fecha_registro date,
	p_estado boolean)
    RETURNS void
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
BEGIN
    UPDATE schemasye."Producto"
    SET 
        nombre = p_nombre,
        precio = p_precio,
        cantidad = p_cantidad,
        fecha_registro = p_fecha_registro,
        estado = p_estado
    WHERE idproducto = p_idproducto;
END;
$BODY$;

ALTER FUNCTION schemasye.actualizar_producto(integer, character varying, double precision, integer, date, boolean)
    OWNER TO postgres;
