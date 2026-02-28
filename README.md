# TaskHub - проект для выполнения домашних заданий курса по ASP.NET

Для развертывания базы данных необходимо установить Docker Desktop (или удобное для вас решение).
В корне репозитория, где находится файл .sln, выполнить команду в терминали docker compose up -d

Команды для применения миграций:
1) Из папки решения устанавливаем тулзу (где .sln): dotnet tool install --global dotnet-ef
2) Генерируем миграции:
   dotnet ef migrations add CreateUsers --project Dal --startup-project Api --context UserDbContext --output-dir Migrations
   2.1) Если упали пробуем сбилдить проект:
   dotnet build Api/Api.csproj
3) Применяем миграции:
   dotnet ef database update --project Dal --startup-project Api --context UserDbContext

   <img width="1770" height="782" alt="image" src="https://github.com/user-attachments/assets/1757a8b7-fad8-424b-8953-6918fd44d001" />
