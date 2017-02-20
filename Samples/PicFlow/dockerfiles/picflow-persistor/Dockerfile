FROM fpommerening/spartakiade2017-rabbitmq:core-base
MAINTAINER Frank Pommerening "frank@pommerening-online.de"
ENV REFRESHED_AT 2017-02-20
ENV Picflow_VERSION 0.0.2

RUN set -x \
	&& wget -O /home/picflow-persistor.7z "https://github.com/fpommerening/Spartakiade2017-RabbitMQ/releases/download/$Picflow_VERSION/picflow-persistor.7z" \
    && p7zip -d /home/picflow-persistor.7z \
    && mv /picflow-persistor/ /app/ \
	&& apt-get purge -y --auto-remove ca-certificates wget p7zip

WORKDIR /app/
ENTRYPOINT ["dotnet", "ImagePersistor.dll"]