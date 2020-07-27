#! /usr/bin/env bash

# chmod +x StartTrainingPPO.sh
# nohup ./StartTrainingPPO.sh &
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

echo
cd '/Users/rsaenz/Documents/Projects/master-thesis/SoccerExperiments'
pwd
ls

echo
echo 'Adding ml-agents to $PATH:'
export PATH=$PATH:/Users/rsaenz/Library/Python/3.7/bin
echo $PATH

echo
echo 'Running 100M experiments with Proximal Policy Optimization (PPO) + Curriculums A+B'
mlagents-learn TrainingConfigPPO.yaml --run-id PPO_CurriculumsAB --num-envs 1 --env builds/mac_exe1/macOS_V12_9Fields_Exe1 --curriculum TrainingCurriculaAB.yaml --no-graphics --force

echo
echo 'Opening TensorBoard to see results for Proximal Policy Optimization (PPO) + Curriculums A+B'
open http://localhost:6006/
tensorboard --logdir=summaries