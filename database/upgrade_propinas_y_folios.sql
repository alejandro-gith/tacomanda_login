-- Ejecutar UNA VEZ sobre una base existente. No borra comandas ni reinicia IDs.
-- Haga un respaldo antes de ejecutarlo y detenga la API durante la actualización.
USE tacomanda;

CREATE TABLE folios_diarios (
  fecha DATE PRIMARY KEY,
  ultimo_numero INT NOT NULL
);

ALTER TABLE comandas
  ADD COLUMN fecha_operativa DATE NULL,
  ADD COLUMN numero_diario INT NULL,
  ADD COLUMN porcentaje_propina DECIMAL(5,2) NOT NULL DEFAULT 0,
  ADD COLUMN propina DECIMAL(8,2) NOT NULL DEFAULT 0;

ALTER TABLE pedidos ADD COLUMN propina DECIMAL(8,2) NOT NULL DEFAULT 0;

-- El historial conserva su ID interno y recibe un folio visible por fecha local.
-- Los datos antiguos se enumeran por ID. Los nuevos se asignan transaccionalmente.
UPDATE comandas AS destino
JOIN (
  SELECT id_comanda,
    DATE(DATE_SUB(fecha, INTERVAL 6 HOUR)) AS dia,
    ROW_NUMBER() OVER (
      PARTITION BY DATE(DATE_SUB(fecha, INTERVAL 6 HOUR)) ORDER BY id_comanda
    ) AS numero
  FROM comandas
) AS calculo ON calculo.id_comanda = destino.id_comanda
SET destino.fecha_operativa = calculo.dia,
    destino.numero_diario = calculo.numero;

ALTER TABLE comandas
  MODIFY COLUMN fecha_operativa DATE NOT NULL,
  MODIFY COLUMN numero_diario INT NOT NULL;

CREATE UNIQUE INDEX ux_comandas_folio_diario ON comandas(fecha_operativa, numero_diario);

INSERT INTO folios_diarios (fecha, ultimo_numero)
SELECT fecha_operativa, MAX(numero_diario)
FROM comandas
GROUP BY fecha_operativa;
