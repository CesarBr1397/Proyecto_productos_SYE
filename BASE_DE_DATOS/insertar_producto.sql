-- FUNCTION: schemasye.insertar_producto(character varying, double precision, integer, date, boolean)

-- DROP FUNCTION IF EXISTS schemasye.insertar_producto(character varying, double precision, integer, date, boolean);

CREATE OR REPLACE FUNCTION schemasye.insertar_producto(
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
INSERT INTO schemasye."Producto" (nombre, precio, cantidad, fecha_registro, estado)
VALUES (p_nombre, p_precio, p_cantidad, p_fecha_registro, p_estado);
END;
$BODY$;

ALTER FUNCTION schemasye.insertar_producto(character varying, double precision, integer, date, boolean)
    OWNER TO postgres;
