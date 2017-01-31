FROM postgres
MAINTAINER Frank Pommerening "frank@pommerening-online.de"
ENV REFRESHED_AT 2017-01-31
ENV POSTGRES_USER spartakiade
ENV POSTGRES_PASSWORD sportfrei
ADD init.sql /docker-entrypoint-initdb.d/
EXPOSE 5432