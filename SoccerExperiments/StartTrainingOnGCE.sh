#! /usr/bin/env bash

# chmod +x StartTrainingOnGCE.sh
# nohup ./StartTrainingOnGCE.sh &
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
echo 'Old experiments and master-thesis repo deleted'
rm -r -f -d models
rm -r -f -d summaries
rm -r -f -d master-thesis
ls
echo

# Download master-thesis
echo 'Clonning master-thesis repo:'
git clone -b master https://github.com/rsaenzi/master-thesis.git

# Run experiments
echo 'Running 100M experiments with Proximal Policy Optimization (PPO) + Curricula F'
mlagents-learn 'master-thesis/SoccerExperiments/TrainingConfigPPO.yaml' --curriculum 'master-thesis/SoccerExperiments/TrainingCurriculaF.yaml' --env='master-thesis/SoccerExperiments/builds/linux_exe1/Linux_v12_9fields_Exe1.x86_64' --run-id=PPO_CurriculaF --num-envs 1 --no-graphics --force

# Shutdown the instance to avoid more charges
sleep 30
sudo shutdown -h now