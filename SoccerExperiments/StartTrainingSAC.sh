#! /usr/bin/env bash

# To make this file executable run 'chmod +x StartTrainingSAC.sh'
# To run this file open a terminal and run './StartTrainingSAC.sh'

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
echo 'Adding ml-agents to $PATH:'
export PATH=$PATH:/Users/rsaenz/Library/Python/3.7/bin
echo $PATH

echo
echo 'Checking Python version:'
which -a python
python3 --version
python3 -m pip -V

echo
echo 'Running experiments with Soft Actor-Critic (SAC):'
mlagents-learn TrainingConfigSAC.yaml --run-id match_sac_no_cl --num-envs 1 --env builds/SoccerAcademyV4_20Fields_SmartRed --no-graphics --debug
#mlagents-learn TrainingConfigSAC.yaml --run-id match_sac_exp_X --num-envs 3 --env builds/SoccerAcademyV3_1Field_SmartRed --save-freq 100000 --no-graphics --force --debug

echo
echo 'Opening TensorBoard to see results for Soft Actor-Critic (SAC):'
open http://localhost:6006/
tensorboard --logdir=summaries
