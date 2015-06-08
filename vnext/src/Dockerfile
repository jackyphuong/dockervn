FROM microsoft/aspnet

COPY ./helloVnext/project.json /src/project.json
WORKDIR /src
RUN ["dnu", "restore"]

COPY ./helloVnext /src
EXPOSE 5004

ENTRYPOINT ["dnx", ".", "Kestrel", "--server.urls", "http://localhost:5004"]
