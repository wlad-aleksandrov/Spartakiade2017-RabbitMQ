
CREATE TABLE "mt_doc_user"
(
    id uuid NOT NULL,
    data jsonb NOT NULL,
    mt_last_modified timestamp with time zone DEFAULT transaction_timestamp(),
    mt_version uuid NOT NULL DEFAULT (md5(((random())::text || (clock_timestamp())::text)))::uuid,
    mt_dotnet_type character varying,
    CONSTRAINT pk_mt_doc_user PRIMARY KEY (id)
);


COMMENT ON TABLE "mt_doc_user"
    IS 'origin:Marten.IDocumentStore, Marten, Version=1.1.0.762, Culture=neutral, PublicKeyToken=null';

INSERT INTO "mt_doc_user"(id, data, mt_last_modified, mt_version, mt_dotnet_type)
	values ('c092e847-1a7d-44aa-8f2c-1cf14bc09f6c',
'{"UserName": "jmeier", "LastName": "Meier", "PasswordHash": "iraooM8GnjeDxvWRY60DoFExBVY=", "Id": "c092e847-1a7d-44aa-8f2c-1cf14bc09f6c", "FirstName": "Jürgen"}',
 '2017-02-22 01:16:53.469985+00', '540d26a7-da43-4dcf-9ef7-f3d3c95120e1', 'FP.Spartakiade2017.PicFlow.Contracts.Dbo.User');
	
INSERT INTO "mt_doc_user"(id, data, mt_last_modified, mt_version, mt_dotnet_type)
	values ('cf7cce87-8733-45b3-b64b-b311c796ddbf',
'{"UserName": "wkaufmann", "LastName": "Kaufmann", "PasswordHash": "iraooM8GnjeDxvWRY60DoFExBVY=", "Id" : "47149ba6-1b42-4a27-8e8d-6ea09e88d43f", "FirstName": "Wolfgang"}',
 '2017-02-22 01:17:32.299342+00', '570d26a7-5b41-4fe9-807c-fdbb3c028dbe', 'FP.Spartakiade2017.PicFlow.Contracts.Dbo.User');

INSERT INTO "mt_doc_user"(id, data, mt_last_modified, mt_version, mt_dotnet_type)
	values ('8862e424-0ea2-4e95-9038-a609201d566e',
'{"UserName": "smueller", "LastName": "Müller", "PasswordHash": "iraooM8GnjeDxvWRY60DoFExBVY=", "Id" : "4c149ba6-974e-4996-8fe3-c0a849f53e09", "FirstName": "Sabine"}',
 '2017-02-22 01:19:08.236635+00', '5e0d26a7-c941-4ed1-853d-b98f8ac7e9eb', 'FP.Spartakiade2017.PicFlow.Contracts.Dbo.User');
 
 INSERT INTO "mt_doc_user"(id, data, mt_last_modified, mt_version, mt_dotnet_type)
	values ('62f6e268-7449-4d95-8510-e8894a855acf',
'{"UserName": "klehmann", "LastName": "Lehmann", "PasswordHash": "iraooM8GnjeDxvWRY60DoFExBVY=", "Id" : "4f149ba6-a147-4191-ae23-f67614dd50b1", "FirstName": "Kevin"}',
 '2017-02-22 01:19:52.800921+00', '610d26a7-0246-489c-b30f-b842ec6c6ca7', 'FP.Spartakiade2017.PicFlow.Contracts.Dbo.User');
	