CREATE DATABASE bsc;

USE bsc;

/*------------------CREATE TABLES----------------------*/

CREATE TABLE cat_estatus_usuarios (
  id_estatus_usuario INT IDENTITY(1,1) PRIMARY KEY,
  estatus_usuarios VARCHAR(100)
);

CREATE TABLE perfiles (
  id_perfil INT IDENTITY(1,1) PRIMARY KEY,
  perfil VARCHAR(100)
);

CREATE TABLE cat_estatus_pedidos (
  id_estatus_pedidos INT IDENTITY(1,1) PRIMARY KEY,
  estatus_pedidos VARCHAR(100)
);

CREATE TABLE categoria_productos (
  id_categoria_producto INT IDENTITY(1,1) PRIMARY KEY,
  categoria_producto VARCHAR(100)
);

CREATE TABLE productos (
  id_producto INT IDENTITY(1,1) PRIMARY KEY,
  id_categoria_producto INT,
  producto VARCHAR(100),
  precio DECIMAL(10, 2),
  cantidad INT,
  FOREIGN KEY (id_categoria_producto) REFERENCES categoria_productos(id_categoria_producto)
);

CREATE TABLE persona (
  id_persona INT IDENTITY(1,1) PRIMARY KEY,
  nombre VARCHAR(100),
  a_paterno VARCHAR(100),
  a_materno VARCHAR(100),
  domicilio VARCHAR(200),
  telefono VARCHAR(20),
  f_nacimiento DATETIME,
  correo VARCHAR(100),
  contrasenia VARCHAR(100),
  f_creacion DATETIME,
  f_modifico DATETIME
);

CREATE TABLE clientes (
  id_cliente INT IDENTITY(1,1) PRIMARY KEY,
  id_persona INT,
  FOREIGN KEY (id_persona) REFERENCES persona(id_persona)
);

CREATE TABLE usuarios (
  id_usuario INT IDENTITY(1,1) PRIMARY KEY,
  id_persona INT,
  id_perfil INT,
  id_estatus_usuario INT,
  FOREIGN KEY (id_persona) REFERENCES persona(id_persona),
  FOREIGN KEY (id_perfil) REFERENCES perfiles(id_perfil),
  FOREIGN KEY (id_estatus_usuario) REFERENCES cat_estatus_usuarios(id_estatus_usuario)
);

CREATE TABLE pedidos (
  id_pedido INT IDENTITY(1,1) PRIMARY KEY,
  id_usuario INT,
  id_cliente INT,
  id_estatus_pedido INT,
  cantidad INT,
  precio_total DECIMAL(10, 2),
  FOREIGN KEY (id_usuario) REFERENCES usuarios(id_usuario),
  FOREIGN KEY (id_cliente) REFERENCES clientes(id_cliente),
  FOREIGN KEY (id_estatus_pedido) REFERENCES cat_estatus_pedidos(id_estatus_pedidos)
);

CREATE TABLE producto_pedido (
  id_producto_pedido INT IDENTITY(1,1) PRIMARY KEY,
  id_producto INT,
  id_pedido INT,
  FOREIGN KEY (id_producto) REFERENCES productos(id_producto),
  FOREIGN KEY (id_pedido) REFERENCES pedidos(id_pedido)
);
