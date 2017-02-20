FROM fpommerening/spartakiade2017-rabbitmq:core-base
MAINTAINER Frank Pommerening "frank@pommerening-online.de"
ENV REFRESHED_AT 2017-01-31
ENV Picflow_VERSION 0.0.1

COPY /app /home/

RUN set -x \
#	&& wget -O /home/picflow-uploader.7z "https://github.com/fpommerening/Spartakiade2017-RabbitMQ/releases/download/$Picflow_VERSION/picflow-uploader.7z" \
    && p7zip -d /home/picflow-uploader.7z \
    && mv /picflow-uploader/ /app/ \
	&& apt-get purge -y --auto-remove ca-certificates wget p7zip

WORKDIR /app/
ENTRYPOINT ["dotnet", "Uploader.dll"]