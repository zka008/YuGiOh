using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections;
using YuGiOh.Data;

namespace YuGiOh.Service
{

    public class MySQLHandler
    {
        private string connectionString;

        //인스턴스 생성 시 DB 연결 주소 생성
        public MySQLHandler()
        {
            string server = "url";
            string port = "port";
            string database = "name";
            string id = "id";
            string pw = "pw";
            connectionString = $"Server={server};Port={port};Database={database};Uid={id};Pwd={pw};";
        }

        // 회원가입 - 아이디, 비밀번호, 이름, 전화번호, 이메일 입력, SQL문 실행 후 변경사항이 있으면 true, 없으면 false
        public bool RegisterMember(string id, string pw, string name, string tel, string email)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO MEMBER (ID, PW, NAME, TEL, EMAIL) VALUES (@id, @pw, @name, @tel, @email)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@pw", pw);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@tel", tel);
                    command.Parameters.AddWithValue("@email", email);

                    int rowsAffected = command.ExecuteNonQuery(); //DB 변경된 부분의 수

                    return rowsAffected > 0;
                }
            }
        }

        // 회원탈퇴 -  아이디로 조회 후 삭제, SQL문 실행 후 변경사항이 있으면 true, 없으면 false
        public bool UnregisterMember(string id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM MEMBER WHERE ID = @id";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        //로그인 - 정보 조회
        public bool LoginMember(string id, string pw)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM MEMBER WHERE ID = @id AND PW = @pw";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@pw", pw);

                    int count = Convert.ToInt32(command.ExecuteScalar());

                    return count == 1;
                }
            }
        }

        //이름, 돈 조회
        public void GetMemberInfo(string id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT NAME, CASH FROM MEMBER WHERE ID = @id";


                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            GameInfo.Member.Id = id;
                            string name = reader["NAME"].ToString();
                            GameInfo.Member.Name = name;
                            int cash = Convert.ToInt32(reader["CASH"]);
                            GameInfo.Member.Cash = cash;
                        }
                    }
                }
            }
        }

        //돈 업데이트
        public void UpdateMemberInfo(string id, int newCash)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // 수정된 쿼리: CASH 열을 새로운 값으로 업데이트
                string query = "UPDATE MEMBER SET CASH=@newCash WHERE ID = @id";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@newCash", newCash);

                    // ExecuteNonQuery를 사용하여 데이터베이스 업데이트 실행
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // 업데이트가 성공했을 때, 해당 멤버의 정보를 다시 불러옴
                        string selectQuery = "SELECT NAME, CASH FROM MEMBER WHERE ID = @id";

                        using (MySqlCommand selectCommand = new MySqlCommand(selectQuery, connection))
                        {
                            selectCommand.Parameters.AddWithValue("@id", id);

                            using (MySqlDataReader reader = selectCommand.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    int cash = Convert.ToInt32(reader["CASH"]);

                                    // 업데이트된 정보를 GameInfo.Member에 저장
                                    GameInfo.Member.Cash = cash;
                                }
                            }
                        }
                    }
                }
            }
        }


        //덱 정보 저장
        public void SaveDeck(string id, List<Card> deck)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO DECK (ID, CARD_NAME) VALUES (@id, @cardName)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    foreach (Card card in deck)
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@cardName", card.Name);
                        command.ExecuteNonQuery();
                        command.Parameters.Clear();
                    }
                }
            }
        }

        //덱 정보 불러오기
        public List<Card> GetDeck(string id)
        {
            List<Card> deck = new List<Card>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM DECK WHERE ID = @id";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = reader["CARD_NAME"].ToString();
                            deck.Add(new Card(name));
                        }
                    }
                }
            }
            return deck;
        }

        //덱 정보 삭제
        public void DeleteDeck(string id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM DECK WHERE ID = @id";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // 성공적으로 삭제된 경우, 메시지 박스 띄울까?
                    }
                    else
                    {
                        // 해당 ID를 가진 행이 없는 경우
                    }
                }
            }
        }
    }
}