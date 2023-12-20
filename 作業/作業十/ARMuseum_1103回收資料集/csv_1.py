import os
import json
import pandas as pd

# 資料夾路徑
folder_path = ''

# # 計數器
# q1_agree_count = 0
# q1_Strong_agree_count = 0  
# q1_Disagree_count = 0
# q1_StrongDisgree_count = 0

# q2_agree_count = 0
# q2_Strong_agree_count = 0  
# q2_Disagree_count = 0
# q2_StrongDisgree_count = 0

# q1_set = set()

csv_DataList = list()

def is_empty_dict(d):
    # 判斷字典是否為空
    return not d

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
                
                with open(json_file) as file:
                    data = json.load(file)
                    print('data:', data)
                    if not is_empty_dict(data):
                        # if len(data['dataList'][0]) != 11: raise Exception('不是11')
                        csv_DataList.append(data['dataList'][0])


# 將資料轉換為 DataFrame
df = pd.DataFrame(csv_DataList)

# 將 DataFrame 轉換為 CSV 檔案
df.to_csv('artist.csv', index=False)


'''
                try:
                    with open(json_file) as file:
                        data = json.load(file)
                        print('data:', data)
                        q1_value = data['dataList'][0]['Q1'].strip()

                        if q1_value == 'Agree':
                            q1_agree_count += 1
                        elif q1_value == 'StrongAgree':
                            q1_Strong_agree_count += 1
                        elif q1_value == 'Disagree':
                            q1_Disagree_count += 1
                        elif q1_value == 'StrongDisgree':
                            q1_StrongDisgree_count += 1
                            
                        q2_value = data['dataList'][0]['Q2'].strip()

                        if q2_value == 'Agree':
                            q2_agree_count += 1
                        elif q2_value == 'StrongAgree':
                            q2_Strong_agree_count += 1
                        elif q2_value == 'Disagree':
                            q2_Disagree_count += 1
                        elif q2_value == 'StrongDisgree':
                            q2_StrongDisgree_count += 1
                  
                except KeyError as e:
                    print(f"KeyError in {json_file}: {e}")
                    continue

# 顯示Q3為"Agree"的總數
print(f'Total count of Q1 "Agree": {q1_agree_count}')
print(f'Total count of Q1 "disagree": {q1_Disagree_count}')
print(f'Total count of Q1 "Strong_agree": {q1_Strong_agree_count}')
print(f'Total count of Q1 "StrongDisgree": {q1_StrongDisgree_count}')





# import json

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

'''