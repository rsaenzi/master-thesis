#! /usr/bin/env bash

# chmod +x TrainingPPO_C.sh
# nohup ./TrainingPPO_C.sh &
# tail -f nohup.out

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
echo 'Old experiments and master-thesis repo deleted:'
rm -r -f -d models
rm -r -f -d summaries
rm -r -f -d master-thesis
ls
echo

# Download master-thesis
echo 'Clonning master-thesis repo:'
git clone -b master https://github.com/rsaenzi/master-thesis.git

# Run experiments
echo 'Experiment: PPO + Curricula C'
mlagents-learn 'master-thesis/SoccerExperiments/algorithms/AlgorithmPPO.yaml' --run-id=V2_PPO_CurriculaC --curriculum 'master-thesis/SoccerExperiments/curriculums/CurriculaC.yaml' --env='master-thesis/SoccerExperiments/builds/Linux_v14_4fields.x86_64' --num-envs 1 --no-graphics --force

# Shutdown the instance to avoid more charges
sleep 30
sudo shutdown -h now