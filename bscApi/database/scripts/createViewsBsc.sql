
/*--------------------------------CREATE VIEWS---------------------------------*/

/*VIEW USUARIOS*/

GO
CREATE VIEW VwGetUsers AS
SELECT 
    p.id_persona, p.nombre, p.a_paterno, p.a_materno, p.domicilio, p.telefono, p.f_nacimiento, p.correo,
    pr.id_perfil AS nombre_perfil,
    eu.estatus_usuarios AS estatus_usuario
FROM 
    persona p
JOIN 
    Usuarios u ON u.id_persona = p.id_persona
JOIN 
    Perfiles pr ON pr.id_perfil = u.id_perfil
JOIN 
    cat_estatus_usuarios eu ON eu.id_estatus_usuario = u.id_estatus_usuario
WHERE 
    u.id_perfil IS NOT NULL;
GO

/*VIEW PRODUCTS*/

GO
CREATE VIEW VwGetProducts AS
SELECT 
    p.*,
    c.categoria_producto
FROM 
    productos p
JOIN 
    categoria_productos c ON c.id_categoria_producto = p.id_categoria_producto
GO

/*VIEW CLIENTS*/

GO
CREATE VIEW VwGetClients AS
SELECT 
    p.id_persona,
	c.id_cliente,
    CONCAT(p.nombre, ' ', p.a_paterno, ' ', p.a_materno) AS nombre_completo
FROM 
    persona p
JOIN 
    clientes c ON p.id_persona = c.id_persona;
GO

/*VIEW ORDERS*/

GO
CREATE VIEW VwGetOrders AS
SELECT 
    p.id_pedido,
	cp.id_estatus_pedidos,
	cp.estatus_pedidos,
	p.cantidad,
	p.precio_total
FROM 
    pedidos p
JOIN 
    cat_estatus_pedidos cp ON p.id_estatus_pedido = cp.id_estatus_pedidos;
GO
