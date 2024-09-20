#!/bin/bash

# Arguments
ENV_FILE=$1
VAR_NAME=$2
NEW_VALUE=$3

# Check if the file exists
if [ ! -f "$ENV_FILE" ]; then
  echo "$ENV_FILE does not exist."
  exit 1
fi

# Update the variable in the file
if grep -q "^$VAR_NAME=" "$ENV_FILE"; then
  sed -i "s/^$VAR_NAME=.*/$VAR_NAME=$NEW_VALUE/" "$ENV_FILE"
else
  echo "$VAR_NAME=$NEW_VALUE" >> "$ENV_FILE"
fi
