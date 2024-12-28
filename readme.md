# APIGateway

## Описание
`APIGateway` — это микросервис из 5-ой лабоработрной работы для маршрутизации запросов к другим микросервисам, таким как `UserService`, `EventService`, `ObjectService`, и `TicketService`. API Gateway предоставляет единый интерфейс для взаимодействия с микросервисами и упрощает управление ими.

---

## Структура проекта

```plaintext
APIGateway/
├── Dependencies/                      # Зависимости проекта, подключенные через NuGet
├── Properties/                        # Конфигурационные файлы и параметры запуска
│   ├── appsettings.json               # Основные настройки приложения
│   ├── appsettings.Development.json   # Настройки для режима разработки
│   ├── launchSettings.json            # Настройки запуска приложения
│   └── ocelot.json                    # Конфигурация Ocelot для маршрутизации
├── Program.cs                         # Точка входа в приложение
```

---

## Настройка Ocelot

API Gateway использует библиотеку **Ocelot** для маршрутизации запросов. Основные маршруты описаны в файле `ocelot.json`. Ниже представлены примеры маршрутов, уже настроенных для взаимодействия с микросервисами:

### Пример конфигурации маршрутов:

```json
{
  "Routes": [
    {
      "DownstreamPathTemplate": "/api/users",
      "DownstreamScheme": "http",
      "DownstreamHostAndPorts": [
        { "Host": "localhost", "Port": 5137 }
      ],
      "UpstreamPathTemplate": "/gateway/users",
      "UpstreamHttpMethod": [ "Get", "Post" ]
    },
    {
      "DownstreamPathTemplate": "/api/users/{id}",
      "DownstreamScheme": "http",
      "DownstreamHostAndPorts": [
        { "Host": "localhost", "Port": 5137 }
      ],
      "UpstreamPathTemplate": "/gateway/users/{id}",
      "UpstreamHttpMethod": [ "Get", "Put", "Delete" ]
    },
    {
      "DownstreamPathTemplate": "/api/events/{everything}",
      "DownstreamScheme": "http",
      "DownstreamHostAndPorts": [
        { "Host": "localhost", "Port": 5294 }
      ],
      "UpstreamPathTemplate": "/gateway/events/{everything}",
      "UpstreamHttpMethod": [ "Get", "Post", "Put", "Delete" ]
    },
    {
      "DownstreamPathTemplate": "/api/objects/{everything}",
      "DownstreamScheme": "http",
      "DownstreamHostAndPorts": [
        { "Host": "localhost", "Port": 5294 }
      ],
      "UpstreamPathTemplate": "/gateway/objects/{everything}",
      "UpstreamHttpMethod": [ "Get", "Post", "Put", "Delete" ]
    },
    {
      "DownstreamPathTemplate": "/api/tickets/{everything}",
      "DownstreamScheme": "http",
      "DownstreamHostAndPorts": [
        { "Host": "localhost", "Port": 5294 }
      ],
      "UpstreamPathTemplate": "/gateway/tickets/{everything}",
      "UpstreamHttpMethod": [ "Get", "Post", "Put", "Delete" ]
    }
  ],
  "GlobalConfiguration": {
    "BaseUrl": "http://localhost:5285"
  }
}
```

---

## Установка и запуск

### Требования:
- .NET 8.0 (или новее)
- IDE с поддержкой .NET
- Ocelot (подключается через NuGet)

### Шаги установки:
1. Склонируй репозиторий:
   ```bash
   git clone https://github.com/Nata-Practices/APIGateway.git
   ```
2. Перейди в папку проекта:
   ```bash
   cd APIGateway
   ```
3. Установи зависимости:
   ```bash
   dotnet restore
   ```

### Запуск приложения:

1. **Запусти связанные микросервисы**:
   - Убедись, что микросервисы `SwaggerAPI` и `UserService` запущены.

2. **Соберите проект API Gateway**:
   ```bash
   dotnet build
   ```

3. **Запустите сервер API Gateway**:
   ```bash
   dotnet run
   ```
   Приложение будет доступно по адресу `http://localhost:5285`.

---

## API Роуты

### Users (через UserService)
- `GET /gateway/users` — получить всех пользователей
- `POST /gateway/users` — создать нового пользователя
- `GET /gateway/users/{id}` — получить пользователя по id
- `PUT /gateway/users/{id}` — обновить пользователя по id
- `DELETE /gateway/users/{id}` — удалить пользователя по id

### Events
- `GET /gateway/events` — получить список событий
- `POST /gateway/events` — создать новое событие
- `GET /gateway/events/{id}` — получить событие по id
- `PUT /gateway/events/{id}` — обновить событие по id
- `DELETE /gateway/events/{id}` — удалить событие по id

### Objects
- `GET /gateway/objects` — получить список объектов
- `POST /gateway/objects` — создать новый объект
- `GET /gateway/objects/{id}` — получить объект по id
- `PUT /gateway/objects/{id}` — обновить объект по id
- `DELETE /gateway/objects/{id}` — удалить объект по id

### Tickets
- `GET /gateway/tickets` — получить список билетов
- `POST /gateway/tickets` — создать новый билет
- `GET /gateway/tickets/{id}` — получить билет по id
- `PUT /gateway/tickets/{id}` — обновить билет по id
- `DELETE /gateway/tickets/{id}` — удалить билет по id

---

## Особенности
- API Gateway упрощает доступ к нескольким микросервисам через единый адрес.
- Поддерживает маршрутизацию, фильтрацию и обработку ошибок с использованием Ocelot.

--- 