# SQS Lambda Trigger Throughput limit

Sample apps showing how to limit throughput in SQS.

## Setup

### Prerequisites

* .NET Core SDK 3.1
* Powershell Core

## Solution structure

### NoLimit

This app shows how Lambda behaves when there is no throughput limit set.

#### Required variables to be set - deploy.ps1

* \[s3-bucket-name\] -> name of the Amazon S3 Bucket used to deploy AWS CloudFormation stacks.

#### Deployment

```powershell
deploy.ps1
```

### Throttling

This app shows how Lambda behaves when there is ReservedConcurrency set.

#### Required variables to be set - deploy.ps1

* \[s3-bucket-name\] -> name of the Amazon S3 Bucket used to deploy AWS CloudFormation stacks.

#### Deployment

```powershell
deploy.ps1
```

### ThroughputLimit

This app shows how to use FIFO SQS and MessageGroupId to set throughput limit.

In this project there is only infrastructure. Trick with MessageGroupId is used in Testing project.

#### Required variables to be set - deploy.ps1

* \[s3-bucket-name\] -> name of the Amazon S3 Bucket used to deploy AWS CloudFormation stacks.

#### Deployment

```powershell
deploy.ps1
```

### Testing

This project contains sample tests which can be used to check how each of the solution behaves.

In `GetMessageGroupId` method you can find the trick with MessageGroupId used to set throughput limit.

#### Required variables to be set - Tests.cs

* queueUrl -> After deployment of each app, you need to set SQS url in the proper test method.