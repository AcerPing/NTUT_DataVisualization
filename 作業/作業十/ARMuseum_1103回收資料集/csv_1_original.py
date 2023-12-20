import os
import json

# 資料夾路徑
folder_path = ''

# 計數器
agree_count = 0
Strong_agree_count = 0  
Disagree_count = 0
StrongDisgree_count = 0


# 處理每個資料夾
for i in range(1, 16):
    folder_name = f'{i:02d}'
    folder_directory = os.path.join(folder_path, folder_name)
    
    # 檢查資料夾是否存在
    if os.path.exists(folder_directory):
        # 進入每個學生的資料夾
        student_folders = os.listdir(folder_directory)
        for student_folder in student_folders:
            student_directory = os.path.join(folder_directory, student_folder)
            
            # 讀取userSequentialAnswer.json檔案
            json_file = os.path.join(student_directory, 'userSequentialAnswer.json')
            if os.path.exists(json_file):
                try:
                    with open(json_file) as file:
                        data = json.load(file)
                        # print(data)
                        q3_value = data['dataList'][0]['Q8'].strip()
                     
                        if q3_value == 'Agree':
                            agree_count += 1
                        elif q3_value == 'StrongAgree':
                            Strong_agree_count += 1
                        elif q3_value == 'Disagree':
                            Disagree_count += 1
                        elif q3_value == 'StrongDisgree':
                            StrongDisgree_count += 1
                      
                except KeyError as e:
                    print(f"KeyError in {json_file}: {e}")
                    continue

# 顯示Q3為"Agree"的總數
print(f'Total count of Q3 "Agree": {agree_count}')
print(f'Total count of Q3 "disagree": {Disagree_count}')
print(f'Total count of Q3 "Strong_agree": {Strong_agree_count}')
print(f'Total count of Q3 "StrongDisgree": {StrongDisgree_count}')



import json

# Your previous code to generate counts

# Storing counts in a dictionary
counts = {
    "Agree": agree_count,
    "Disagree": Disagree_count,
    "StrongAgree": Strong_agree_count,
    "StrongDisagree": StrongDisgree_count
}

# Saving as JSON
output_file = 'counts.json'
with open(output_file, 'w') as json_file:
    json.dump(counts, json_file, indent=4)

print(f'Counts saved in {output_file}')