pipeline {
    agent any

    stages {
        stage('Restore Dependencies') {
            steps {
                sh 'dotnet restore DemoQa.sln'
            }
        }

        stage('Build Project') {
            steps {
                sh 'dotnet build DemoQa.sln --no-restore'
            }
        }

        stage('Run MSTest Tests') {
            steps {
                sh 'dotnet test DemoQa.sln --no-build --verbosity normal'
            }
        }
    }
}
