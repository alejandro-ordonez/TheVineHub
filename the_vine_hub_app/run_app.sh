#!/bin/bash

# run_app.sh
# Usage: ./run_app.sh -ApiUrl "http://localhost:5000" -Device "web-server" -Port 8080

# Default values
API_URL="http://localhost:5000"
DEVICE=""
PORT=0

# Parse arguments
while [[ "$#" -gt 0 ]]; do
    case $1 in
        -ApiUrl) API_URL="$2"; shift ;;
        -Device) DEVICE="$2"; shift ;;
        -Port) PORT="$2"; shift ;;
        *) echo "Unknown parameter: $1"; exit 1 ;;
    esac
    shift
done

DEVICE_ARGS=()
if [ -n "$DEVICE" ]; then
    DEVICE_ARGS=("-d" "$DEVICE")
fi

PORT_ARGS=()
if [ "$PORT" -gt 0 ]; then
    PORT_ARGS=("--web-port" "$PORT")
fi

# Colors
CYAN='\033[0;36m'
GRAY='\033[0;90m'
NC='\033[0m' # No Color

echo -e "${CYAN}Starting JM Ministry App${NC}"
echo -e "${GRAY}API_BASE_URL: $API_URL${NC}"
if [ -n "$DEVICE" ]; then
    echo -e "${GRAY}Device: $DEVICE${NC}"
fi
if [ "$PORT" -gt 0 ]; then
    echo -e "${GRAY}Port: $PORT${NC}"
fi

flutter run "${DEVICE_ARGS[@]}" "${PORT_ARGS[@]}" --dart-define=API_BASE_URL="$API_URL"
