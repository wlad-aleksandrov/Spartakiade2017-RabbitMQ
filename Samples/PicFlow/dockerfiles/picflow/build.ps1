
$zip = "c:\Program Files\7-Zip\7z.exe"
$projectPath = 'C:\Projects\Spartakiade2017-RabbitMQ\Samples\PicFlow'
$tempPath = 'c:\temp\spartakiade'

$projects = @{
    'Authorization' = 'picflow-authorization';
    'ImagePersistor' = 'picflow-persistor';
    'ImageProcessor' = "picflow-processor";
    'Uploader' = "picflow-uploader";
    'WebApp' = "picflow-webapp";
    'ExternalApp' = "picflow-extapp";
}

$projects.GetEnumerator() |
     ForEach-Object {
        & dotnet 'publish' ('"{0}\src\{1}"' -f $projectPath, $_.Key)-c Release -o('"{0}\{1}"'-f  $tempPath, $_.Value)
        & $zip a ("{0}\dockerfiles\{1}\app\{1}.7z" -f $projectPath, $_.Value)  ("{0}\{1}" -f $tempPath, $_.Value)
        & docker build -f ("{0}\dockerfiles\{1}\Dockerfile.local" -f $projectPath, $_.Value) -t ("fpommerening/spartakiade2017-rabbitmq:{0}" -f $_.Value) ("{0}\dockerfiles\{1}\" -f $projectPath, $_.Value) 
    }


