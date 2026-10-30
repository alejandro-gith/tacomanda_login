CREATE TABLE empleados (
  id CHAR(36) PRIMARY KEY,
  usuario VARCHAR(50) NOT NULL UNIQUE,
  nombre VARCHAR(100) NOT NULL,
  rol VARCHAR(20) NOT NULL,
  password_hash VARCHAR(255) NOT NULL,
  activo BOOLEAN NOT NULL DEFAULT TRUE
);
CREATE TABLE platillos (
  id CHAR(36) PRIMARY KEY,
  nombre VARCHAR(80) NOT NULL UNIQUE,
  categoria VARCHAR(50) NOT NULL,
  descripcion VARCHAR(250) NOT NULL DEFAULT '',
  precio DECIMAL(10,2) NOT NULL,
  emoji VARCHAR(16) NOT NULL DEFAULT '🌮',
  activo BOOLEAN NOT NULL DEFAULT TRUE,
  CHECK (precio > 0)
);
CREATE TABLE mesas (
  id CHAR(36) PRIMARY KEY,
  nombre VARCHAR(40) NOT NULL UNIQUE,
  estado VARCHAR(20) NOT NULL
);
CREATE TABLE comandas (
  id CHAR(36) PRIMARY KEY,
  numero INT NOT NULL UNIQUE,
  mesa_id CHAR(36) NOT NULL,
  mesero_id CHAR(36) NOT NULL,
  estado VARCHAR(20) NOT NULL,
  creada_en TIMESTAMP NOT NULL,
  FOREIGN KEY (mesa_id) REFERENCES mesas(id),
  FOREIGN KEY (mesero_id) REFERENCES empleados(id)
);
CREATE TABLE detalles_comanda (
  id CHAR(36) PRIMARY KEY,
  comanda_id CHAR(36) NOT NULL,
  platillo_id CHAR(36) NOT NULL,
  nombre_platillo VARCHAR(80) NOT NULL,
  precio_unitario DECIMAL(10,2) NOT NULL,
  cantidad INT NOT NULL,
  observacion VARCHAR(200) NOT NULL DEFAULT '',
  FOREIGN KEY (comanda_id) REFERENCES comandas(id),
  FOREIGN KEY (platillo_id) REFERENCES platillos(id),
  CHECK (cantidad > 0), CHECK (precio_unitario > 0)
);
CREATE TABLE pagos (
  id CHAR(36) PRIMARY KEY,
  comanda_id CHAR(36) NOT NULL UNIQUE,
  cajero_id CHAR(36) NOT NULL,
  metodo VARCHAR(20) NOT NULL,
  total DECIMAL(10,2) NOT NULL,
  recibido DECIMAL(10,2) NOT NULL,
  cambio DECIMAL(10,2) NOT NULL,
  pagado_en TIMESTAMP NOT NULL,
  FOREIGN KEY (comanda_id) REFERENCES comandas(id),
  FOREIGN KEY (cajero_id) REFERENCES empleados(id)
);
