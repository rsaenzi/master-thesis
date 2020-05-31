#! /usr/bin/env bash

# To run this file open a terminal and type ./run_experiments.sh

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
cd '/Users/rsaenz/Documents/Projects/MasterThesis/SoccerExperiments'
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
#mlagents-learn -h
mlagents-learn config/trainer_config.yaml --run-id=experiment_run_1 

#--env '/Users/rsaenz/Documents/Projects/MasterThesis/SoccerExperiments/Executable'
#--curriculum '/Users/rsaenz/Documents/Projects/MasterThesis/SoccerExperiments/Curriculum.yaml'
#--lesson 0
#--run-id MyTrainingSessionId 
#--num-envs 1
#--save-freq 10000
#--no-graphics true
#--cpu
#--force

echo
echo 'Opening TensorBoard:'
open http://localhost:6006/
tensorboard --logdir=summaries
