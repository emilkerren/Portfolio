import requests
import time


def main():
    rates_list = poller()
    total_sum = sum(rates_list)
    average = total_sum / len(rates_list)
    f = open("average_rates.txt", "w+")
    f.write(str(average))
    f.close()


def poller(polling_interval=5, polling_duration=60):
    average_list = []
    api_key = "210879f604a7469ca6d79db570034d64"
    currency_code = "EUR"
    currency_freaks_url = f"https://api.currencyfreaks.com/v2.0/rates/latest?\
apikey={api_key}&symbols={currency_code}"
    num_polls = polling_duration // polling_interval
    poller_starttime = time.time()
    for i in range(num_polls):
        try:
            response = requests.get(currency_freaks_url)
            if response.status_code == 200:
                data = response.json()
                if "EUR" in data["rates"]:
                    rate = float(data["rates"]["EUR"])
                    elapsed_time = time.time() - poller_starttime
                    print(f"Poll {i + 1}, Rate:", rate, f"[time elapsed: \
{elapsed_time}]")
                    average_list.append(rate)
            else:
                print(f"Poll {i + 1}: URL is not accessible (Status Code \
{response.status_code})")

        except requests.exceptions.RequestException as e:
            print(f"Poll {i + 1}: Error while polling the URL: {e}")

        # Sleep for the specified polling interval
        time.sleep(polling_interval)

    print("Polling complete.", average_list)
    return average_list


if __name__ == "__main__":
    main()
