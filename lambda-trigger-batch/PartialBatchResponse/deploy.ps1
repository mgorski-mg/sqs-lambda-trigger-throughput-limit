dotnet lambda deploy-serverless `
    --configuration Release `
    --region eu-west-1 `
    --stack-name sqs-lambda-batch `
    --s3-bucket [s3-bucket-name] `
    --s3-prefix sqs-lambda/batch/ `
    --template application.yaml `
    --tags "service-name=sqs-lambda-batch";