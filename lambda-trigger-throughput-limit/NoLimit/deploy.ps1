dotnet lambda deploy-serverless `
    --configuration Release `
    --region eu-west-1 `
    --stack-name sqs-lambda-no-limit `
    --s3-bucket [s3-bucket-name] `
    --s3-prefix sqs-lambda/no-limit/ `
    --template application.yaml `
    --tags "service-name=sqs-lambda-no-limit";