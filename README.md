### Ship management
Ship management system where you can register, edit, remove, and search for ships in our system. This system caters to end-users through a simple and friendly interface where it's possible to select their preferred language. Additionally, for developers, we offer an API that can be consumed for managing and creating dashboards.

### Technologies

**Backend:** 

    - Asp .NET Core 7.0;
    - Entity Framework with a InMemory datatabase;
    - Fluent Validation;
    - Swaegger;
    - AutoMapper;

**Frontend:** 

    - React (created by react-create-app);
    - Material UI;

**Architecture:**

    Clean Architecture with Unit Tests;

### Pre requirements:

    - Yarn
    - Docker

### How to run the project:

Clone the project:

```bash
$ git clone https://github.com/evertonoliveira1/omoqo-code-challenge.git
$ cd omoqo-code-challenge
```

Execute the command to run the containers

```bash
$ docker compose up
```

- **Web Application:** [http://localhost:3000](http://localhost:3000)
- **API:** [https://localhost:8080/api](https://localhost:8080/api)
- **API docs:** [https://localhost:8080/swagger/index.html](https://localhost:8080/swagger/index.html)