pipeline {
    agent any

    stages {
        stage('Check Workspace Files') {
            steps {
                sh 'ls -la'
            }
        }

        stage('Restore Dependencies') {
            steps {
                sh 'dotnet restore'
            }
        }

        stage('Build Project') {
            steps {
                sh 'dotnet build --no-restore'
            }
        }

        stage('Run MSTest Tests') {
            steps {
                sh 'dotnet test --no-build --verbosity normal'
            }
        }
    }
}
