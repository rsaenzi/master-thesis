#! /usr/bin/env bash

# To make this file executable run 'chmod +x TrainSoccer.sh'
# To run this file open a terminal and run './TrainSoccer.sh'

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
echo 'Current Directory:'
cd '/Users/rsaenz/Documents/Projects/master-thesis/SoccerExperiments'
pwd
ls

echo
echo 'Adding mlagents to $PATH:'
export PATH=$PATH:/Users/rsaenz/Library/Python/3.7/bin
echo $PATH

echo
echo 'Checking Python version:'
which -a python
python3 --version
python3 -m pip -V

echo
echo 'Running ML-Agents:'
mlagents-learn TrainingConfig.yaml --env SoccerAcademy_2Fields_1Agent --run-id match_no_curriculum_2 --save-freq 100000 --num-envs 1 --no-graphics
#mlagents-learn TrainingConfig.yaml --env SoccerAcademy --run-id match_no_curriculum_X --save-freq 100000 --num-envs 3 --no-graphics --force --debug

echo
echo 'Opening TensorBoard:'
open http://localhost:6006/
tensorboard --logdir=summaries
