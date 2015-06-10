FROM microsoft/aspnet                                                                                                      
                                                                                                                                                                
ENV NODE_VERSION 0.10.38                                                                                                                                        
ENV NPM_VERSION 2.11.1                                                                                                                                          
                                                                                                                                                                
RUN gpg --keyserver pool.sks-keyservers.net --recv-keys 7937DFD2AB06298B2293C3187D33FF9D0246406D 114F43EE0176B71C7BC219DD50A3051F888C628D                       
                                                                                                                                                                
RUN curl -SLO "http://nodejs.org/dist/v$NODE_VERSION/node-v$NODE_VERSION-linux-x64.tar.gz" \                                                                    
        && curl -SLO "http://nodejs.org/dist/v$NODE_VERSION/SHASUMS256.txt.asc" \                                                                               
        && gpg --verify SHASUMS256.txt.asc \                                                                                                                    
        && grep " node-v$NODE_VERSION-linux-x64.tar.gz\$" SHASUMS256.txt.asc | sha256sum -c - \                                                                 
        && tar -xzf "node-v$NODE_VERSION-linux-x64.tar.gz" -C /usr/local --strip-components=1 \                                                                 
        && rm "node-v$NODE_VERSION-linux-x64.tar.gz" SHASUMS256.txt.asc \                                                                                       
        && npm install -g npm@"$NPM_VERSION" \                                                                                                                  
        && npm install -g bower \                                                                                                                               
        && apt-get install -y git \                                                                                                                             
        && npm install --global -y gulp \                                                                                                                       
        && npm cache clear                                                                                                                                      
                                                                                                                                                             
COPY ./project.json /src/project.json                                                                                                                
COPY ./bower.json /src/bower.json                                                                                                                    
COPY ./gulpfile.js /src/gulpfile.js                                                                                                                  
COPY ./package.json /src/package.json                                                                                                                
WORKDIR /src                                                                                                                                                    
RUN ["dnu", "restore"]                                                                                                                                          
                                                                                                                                                                
COPY . /src                                                                                                                                          
EXPOSE 5004                                                                                                                                                     
                                                                                                                                                                
ENTRYPOINT ["dnx", ".", "Kestrel", "--server.urls", "http://localhost:5004"]                                                                                    