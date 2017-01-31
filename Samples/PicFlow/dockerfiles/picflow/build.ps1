
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

$projects.Keys |
     ForEach-Object {
        Set-Location ('"{0}\src\{1}"' -f $projectPath, $_) 
        & dotnet 'publish' ('-c Release -o {0}\{1}'-f $tempPath, $projects.Item($_))
        Set-Location $tempPath
        & $zip a ('{0}.7z' -f  $projects.Item($_))  (' {0}\{1}' -f $tempPath, $projects.Item($_))
        Set-Location ('"{0}\dockerfiles\{1}"' -f $projectPath, $_) 
        Copy-Item (' {0}\{1}.7z' -f $tempPath, $projects.Item($_)) 
        & docker 'build' ('-t fpommerening/devopenspace2016:{0} . ' -f $projects.Item($_))
    }


