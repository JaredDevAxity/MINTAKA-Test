FROM microsoft/dotnet:2.2-aspnetcore-runtime AS final
WORKDIR /app
COPY app/. /app/.
ENTRYPOINT ["dotnet","[%= company %].[%= name %].Api.dll"]