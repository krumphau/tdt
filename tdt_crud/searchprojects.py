from app import app
from flask import flash, request
import sqlhelper

@app.route('/search', methods=['POST'])
def project_search():
    try:
        content = request.json
        _identifier = content['Identifier']
        _region = content['RegionID'] 
        _name = content['Name']
        _NGOId = content['NGOId'] 
        _keywords = content['Keywords'] 
        _officerid = content['OfficerId'] 
        _statuscode = content['Status']
        _funderid = content['FunderId']
        _catid = content['CategoryId']
        _districtid = content['DistrictId']
        _otherbodyid = content['OtherBodyId']

        sql = "CALL usp_SearchProjects(%s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s)"
        data = (_identifier, _region, _name, _NGOId, _keywords, _officerid, _statuscode, _funderid,_catid,_districtid,_otherbodyid,)
        resp = sqlhelper.do_selectmultibyid(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)        