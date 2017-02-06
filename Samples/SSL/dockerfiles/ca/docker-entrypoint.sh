#!/bin/sh
cd /rabbitssl/ca
mkdir certs/
mkdir private
chmod 700 private
echo 01 > serial
touch index.txt

openssl req -x509 -config openssl.cnf -newkey rsa:4096 -days 365 -out cacert.pem -outform PEM -subj /CN=MyTestCA/ -nodes
openssl x509 -in cacert.pem -out cacert.cer -outform DER


mkdir /rabbitssl/server
cd /rabbitssl/server
openssl genrsa -out key.pem 4096
openssl req -new -key key.pem -out req.pem -outform PEM -subj /CN=$(hostname)/O=server/ -nodes
cd /rabbitssl/ca
openssl ca -config openssl.cnf -in /rabbitssl/server/req.pem -out /rabbitssl/server/cert.pem -notext -batch -extensions server_ca_extensions
cd /rabbitssl/server
openssl pkcs12 -export -out keycert.p12 -in cert.pem -inkey key.pem -passout pass:MySecretPassword

mkdir /rabbitssl/client
cd /rabbitssl/client
openssl genrsa -out key.pem 4096
openssl req -new -key key.pem -out req.pem -outform PEM -subj /CN=$(hostname)/O=client/ -nodes
cd /rabbitssl/ca
openssl ca -config openssl.cnf -in /rabbitssl/client/req.pem -out /rabbitssl/client/cert.pem -notext -batch -extensions client_ca_extensions
cd /rabbitssl/client
openssl pkcs12 -export -out keycert.p12 -in cert.pem -inkey key.pem -passout pass:MySecretPassword
