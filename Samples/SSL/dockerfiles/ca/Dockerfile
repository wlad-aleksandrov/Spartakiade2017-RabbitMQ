FROM debian:jessie
MAINTAINER Frank Pommerening "frank@pommerening-online.de"
ENV REFRESHED_AT 2017-01-25

RUN set -x \
	&& apt-get update && apt-get install -y --no-install-recommends openssl && rm -rf /var/lib/apt/lists/* \
	&& apt-get purge -y --auto-remove

COPY openssl.cnf /rabbitssl/ca/
COPY docker-entrypoint.sh /usr/local/bin/

VOLUME ["/rabbitssl"]

ENTRYPOINT ["docker-entrypoint.sh"]