/*INSERTAR DATA*/
--------------------------- 1. cat_estatus_usuarios----------------------

INSERT INTO cat_estatus_usuarios (estatus_usuarios)
VALUES ('Activo'),
       ('Inactivo');
	   
----------------------------------- 2. perfiles-------------------------------

INSERT INTO perfiles (perfil)
VALUES ('Administrador'), ('Administrativo'),  ('Vendedor');

--------------------------------- 3. cat_estatus_pedidos---------------------------

INSERT INTO cat_estatus_pedidos (estatus_pedidos)
VALUES ('Pendiente'), ('Enviado'), ('Entregado');


------------------------------ 4. categoria_productos-----------------------------

INSERT INTO categoria_productos (categoria_producto)
VALUES ('Electrónica'), ('Ferretería'), ('Ropa '), ('Línea Blanca'), ('Juguetería');

------------------------------- 5. productos-----------------------------------

INSERT INTO productos (id_categoria_producto, producto, precio, cantidad)
VALUES 
(1, 'Laptop', 34000.00, 20),
(1, 'Adaptador', 80.00, 50),
(1, 'Audífono', 35.00, 20),
(2, 'Foco', 55.00, 30),
(2, 'Martillo ', 300.00, 50),
(2, 'Juego de destornilladores', 389.00, 30),
(3, 'Playera', 250.00, 20),
(3, 'Jeans', 800.00, 50),
(3, 'Short', 200.00, 20),
(4, 'Refrigerador', 18000.00, 10),
(4, 'Lavadora', 12000.00, 10),
(4, 'Estufa', 5900.00, 20),
(5, 'Muñeca', 78.00, 20),
(5, 'Carritos', 167.00, 40),
(5, 'Pelota', 12.00, 5);

----------------------------- 6. persona -------------------------

INSERT INTO persona (
  nombre, a_paterno, a_materno, domicilio, telefono, f_nacimiento,
  correo, contrasenia, f_creacion, f_modifico
)
VALUES (
  'Jose', 'Ramírez', 'García', 'Manuel Acunia 1345', '235345',
  '1988-11-05', 'jose@gmail.com',
  HASHBYTES('SHA2_256', CONVERT(VARCHAR(100), 'asdfgh1.')),
  GETDATE(), GETDATE()
);

---
-- Registro 2
INSERT INTO persona (
  nombre, a_paterno, a_materno, domicilio, telefono, f_nacimiento,
  correo, contrasenia, f_creacion, f_modifico
)
VALUES (
  'Kevin', 'Hernández', 'Díaz', 'Manuel Acunia 1345', '235345',
  '1975-03-12', 'kevin@gmail.com',
  HASHBYTES('SHA2_256', CONVERT(VARCHAR(100), 'asdfgh2.')),
  GETDATE(), GETDATE()
);

---
-- Registro 3
INSERT INTO persona (
  nombre, a_paterno, a_materno, domicilio, telefono, f_nacimiento,
  correo, contrasenia, f_creacion, f_modifico
)
VALUES (
  'Demetria', 'Torres', 'Ruiz', 'Manuel Acunia 1345', '235345',
  '2000-01-30', 'demetria@gmail.com',
  HASHBYTES('SHA2_256', CONVERT(VARCHAR(100), 'asdfgh3.')),
  GETDATE(), GETDATE()
);



-------------------- 7. clientes ----------------------------

INSERT INTO clientes (id_persona)
VALUES (4);

---------------------- 8. usuarios --------------------

INSERT INTO usuarios (id_persona, id_perfil, id_estatus_usuario)
VALUES (3, 3, 1);