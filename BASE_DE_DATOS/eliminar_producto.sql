-- FUNCTION: schemasye.eliminar_producto(integer)

-- DROP FUNCTION IF EXISTS schemasye.eliminar_producto(integer);

CREATE OR REPLACE FUNCTION schemasye.eliminar_producto(
	p_idproducto integer)
    RETURNS void
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
BEGIN
    UPDATE schemasye."Producto"
    SET estado = FALSE
    WHERE idproducto = p_idproducto;
END;
$BODY$;

ALTER FUNCTION schemasye.eliminar_producto(integer)
    OWNER TO postgres;
