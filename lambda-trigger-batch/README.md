# SQS Lambda Trigger Batch

Sample apps showing how to integrate SQS and Lambda consuming messages as batch.

## Setup

### Prerequisites

* .NET Core SDK 3.1
* Powershell Core

## Solution structure

### PartialBatchResponse

This app shows how you can use Partial Batch Response in Lambda to inform SQS which message in the batch failed.

#### Required variables to be set - deploy.ps1

* \[s3-bucket-name\] -> name of the Amazon S3 Bucket used to deploy AWS CloudFormation stacks.

#### Deployment

```powershell
deploy.ps1
```

### Testing

This project contains sample test which can be used to populate SQS with messages.

#### Required variables to be set - Tests.cs

* queueUrl -> After deployment of the app, you need to set SQS url in the test method.