# ef migration
dotnet ef migrations add identityMigrations_initil -o ./Persistence/Migrations/Identity/ -s ../InstantMessaging-IM.API/InstantMessaging-IM.API.csproj -c InstantMessaging-IM.Infrastructure.Persistence.IdentityDbContext


dotnet ef migrations add InstantMessagingMigrations_initil -o ./Persistence/Migrations/InstantMessaging/ -s ../InstantMessaging-IM.API/InstantMessaging-IM.API.csproj -c InstantMessaging-IM.Infrastructure.Persistence.InstantMessagingDbContext

# new host config
-user secrets
	- dotnet user-secrets set "JwtSettings:Secret" "byWV/Vt+EIXiMdkcoMoc7pPcTb21CjjYU3ItzHn9NUWTt/TvJgE6g0xlA/Zh/zIRTDeUBGRYLtkx4l/y+u8J1IsiCrhN10vOwE4m0gEWy6Ic3KNCs5lqqCFRf86IWkqL9WY9NLSHot6VwRBQWwsJfodC8ZRndJsnUuwdwZi+PzrYgN4BZPI4r2rZDFBYzrenON3Z8dUzWAFvQj9O9NB+7KpyG1FVqWq/iFLwokLIn+DdziKxBpRdlWAEe4hbkRuDnik7j2lPOTUyOg+1dRe5XdOWtD5+EI/hiyzqZjnuxkY3B3H1peVFYERHM5mjRQqbU6GOk4pZYrISiroVxuCT8NhynLus/8orZLr1xp8yAwg="
	- dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=127.0.0.1;Port=5432;Database=IMdb;User Id=postgres;Password=postgres;"
	#- dotnet user-secrets set "HashIdSettings:Salt" "InsurLink"

-DB
	- dotnet ef database update -c  InstantMessaging_IM.Infrastructure.Persistence.IdentityDbContext
	- dotnet ef database update -c  InstantMessaging_IM.Infrastructure.Persistence.InstantMessagingDbContext
	- dotnet ef database drop -c InsurLink.Infrastructure.Persistence.InstantMessagingDbContext