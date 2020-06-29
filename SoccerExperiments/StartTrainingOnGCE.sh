#! /usr/bin/env bash

# To make this file executable run 'chmod +x StartTrainingOnGCE.sh'
# To run this file open a terminal and run './StartTrainingOnGCE.sh'

clear

echo
echo '-------------------------------------------------------------------------------------------------------------'
echo
echo 'Evaluating the impact of Curriculum Learning on the training process for an intelligent agent in a video game'
echo 'Maestría en Ingeniería de Sistemas y Computación, Modalidad Profundización'
echo 'Universidad Nacional de Colombia - Sede Bogotá'
echo
echo 'Supervised by:'
echo 'PhD. Jorge Eliecer Camargo Mendoza'
echo 'jecamargom@unal.edu.co'
echo
echo 'Presented by:'
echo 'Rigoberto Sáenz Imbacuán'
echo 'rsaenzi@unal.edu.co'
echo
echo '-------------------------------------------------------------------------------------------------------------'
echo

# Delete previous results
rm -r -f -d models
rm -r -f -d summaries

# Download master-thesis
rm -r -f -d master-thesis
git clone -b master https://github.com/rsaenzi/master-thesis.git

# Test ml-agents
mlagents-learn -h

# Run experiments
echo 'Running 100M experiments with Proximal Policy Optimization (PPO) + Curricula A:'
mlagents-learn 'master-thesis/SoccerExperiments/TrainingConfigPPO.yaml' --env='master-thesis/SoccerExperiments/builds/linux/Linux_v11_4fields.x86_64' --run-id=PPO_CurriculaA --num-envs 1 --curriculum 'master-thesis/SoccerExperiments/TrainingCurriculaA.yaml' --no-graphics --force

# Shutdown the instance to avoid more charges
sleep 30
sudo shutdown -h now