# OrderAPI
# Описание
Добро пожаловать! Это приложение Web API, выполняющее базовые CRUD операции для таблиц товаров, заказов и клиентов.
#Ссылка на сайт с выгруженным проектом
Рабочую версию сайта вы можете найти по ссылке: https://orderdbapp-vitoria.amvera.io/
#Запросы
Список всех рабочих запросов 
   * /client/all                   - возвращает все записи из таблицы клиентов
   * /client/get?id=ClientId       - возвращает запись с клиентом по его id
   * /client/add                   - добавляет клиента в таблицу (требуется отправлять json с клиентом)
   * /client/update?id=ClientId    - обновляет клиента в таблице (требуется отправлять json с клиентом)
   * /client/delete?id=ClientId    - удаляет клиента в таблице по его id 
    
   * /product/all                   - возвращает все записи из таблицы товаров
   * /product/get?id=ProductId      - возвращает запись с товаром по его id
   * /product/add                   - добавляет товар в таблицу (требуется отправлять json с товаром)
   * /product/update?id=ProductId   - обновляет товар в таблице (требуется отправлять json с товаром)
   * /product/delete?id=ProductId   - удаляет товар в таблице по его id 
    
   * /order/all                   - возвращает все записи из таблицы заказов
   * /order/fullAll?id=OrderId    - возвращает все записи из таблицы заказов с подгруженными таблицами
   * /order/get?id=OrderId        - возвращает запись с заказом по его id
   * /order/add                   - добавляет заказ в таблицу (требуется отправлять json с заказом)
   * /order/update?id=OrderId     - обновляет заказ в таблице (требуется отправлять json с заказом)
   * /order/delete?id=OrderId     - удаляет заказ в таблице по его id 
   
   * /order_product/all                   - возвращает все записи из расшивки Товар-Заказ
   * /order_product/get?id=ClientId       - возвращает запись по id
   * /order_product/add                   - добавляет запись в расшивку Товар-Заказ (требуется отправлять json с OrderProduct)
   * /order_product/update?id=ClientId    - обновляет запись в расшивке Товар-Заказ (требуется отправлять json с OrderProduct)
   * /order_product/delete?id=ClientId    - удаляет запись в расшивке Товар-Заказ по id 
   
   * /check?OrderId=id              - возвращает список продуктов и их общую стоимость по id Заказа
   * /fullOrderInfo?OrderId=id      - возвращает список OrderProduct и их общее колличество по id Заказа