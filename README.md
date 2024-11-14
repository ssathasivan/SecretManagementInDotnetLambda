# Secrets Management in .NET Lambda: AWS SDK vs. Lambda Extension

This repository contains the source code of 2 .NET 8 Lambda Functions developed using ASP.NET Core Minimal API that demonstrate how to manage secrets in AWS Lambda. 
The first function uses the AWS SDK to retrieve secrets from AWS Secrets Manager, while the second function uses the Lambda Extension for Secrets Manager 
to retrieve secrets.


### LambdaWithSecretAWSSDK ##

This folder contains the source code of a .NET 8 Lambda Function - (Lambda.Secrets.AWSSDK.sln) developed using ASP.NET Core Minimal API 
that demonstrates how to manage secrets in AWS Lambda using the AWS SDK.

### LambdaWithSecretManagerExtension ###

This folder contains the source code of a .NET 8 Lambda Function - Lambda.Secrets.Extension.sln) developed using ASP.NET Core Minimal API that demonstrates how 
to manage secrets in AWS Lambda using the Lambda Extension for Secrets Manager.

## Test : AWS Lambda Power Tuning ###
AWS Lambda Power Tuning (https://github.com/alexcasalboni/aws-lambda-power-tuning) was used to test the performance of the Lambda functions.

-  Lambda functions were with the following memory configurations: 128 MB, 256 MB, 512 MB, 1024 MB, 2048 MB, 2560 MB,3072 MB. 
-  Each configuration was invoked 100 times.
-  Lambda invocations were done in parallel and had a combination of cold starts and warm starts.

 AWS Lambda Power Tuning measured  execution time and calculated the associated costs, providing insights into performance improvements.

## Test Results ###

The test confirmed our expectations that lambda that retrieves the secret using Lambda Extension is always more performant and cheaper than the lambda that retrieves the secret using AWS SDK. 

<img src="PerformanceResults.png" alt="Before image">

### Execution Time 

| Memory Allocation |  AWS Secrets SDK (ms) | Secrets Manager Extension  (ms)|
|:------------------|:-----------------:|--------------------------:|
| 128 MB    | 10738 | 6171 |
| 256 MB    |  5155 | 3189 |
| 512 MB    |  1762 | 1391 |
| 1024 MB   |   934 |  716 |
| 1536 MB   |   657 |  191 |
| 2048 MB   |   398 |  285 |
| 2560 MB   |   370 |  310 |
| 3072 MB   |   446 |  115 |

### Cost

| Memory Allocation |  AWS Secrets SDK ($) | Secrets Manager Extension  ($)|
|:------------------|:-----------------:|--------------------------:|
| 128 MB    | 0.00002127 | 0.00001172 |
| 256 MB    | 0.00001919 | 0.00001089 |
| 512 MB    | 0.00001136 | 0.00000797 |
| 1024 MB   | 0.00000955 | 0.00000609 |
| 1536 MB   | 0.00000856 | 0.00000204 |
| 2048 MB   | 0.00000658 | 0.00000369 |
| 2560 MB   | 0.00000764 | 0.00000512 |
| 3072 MB   | 0.00001083 | 0.00000246 |
