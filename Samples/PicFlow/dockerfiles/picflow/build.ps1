
$zip = 'c:\Program Files\7-Zip"\7z'
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
        Set-Location ('"{0}\src\{1}"' -f $projectPath, $_.Key) 
        & dotnet 'publish' ('-c Release -o {0}\{1}'-f $tempPath, $_.Value)
        Set-Location $tempPath
        & $zip a ('{0}.7z' -f  $_.Value)  (' {0}\{1}' -f $tempPath, $_.Value)
        Set-Location ('"{0}\dockerfiles\{1}"' -f $projectPath, $_) 
        Copy-Item (' {0}\{1}.7z' -f $tempPath, $_.Value) 
        & docker 'build' ('-t fpommerening/spartakiade2017-rabbitmq:{0} . ' -f $_.Value)
    }


