FROM microsoft/aspnet

COPY ./helloVnext /src
WORKDIR /src

RUN ["dnu", "restore"]

EXPOSE 5004

ENTRYPOINT ["dnx", ".", "Kestrel", "--server.urls", "http://localhost:5004"]
